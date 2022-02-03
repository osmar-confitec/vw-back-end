using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Interfaces;
using VolksCalls.Domain.Models;
using VolksCalls.Domain.Models.Archive;
using VolksCalls.Domain.Models.CallForm;
using VolksCalls.Domain.Models.Calls;
using VolksCalls.Domain.Models.Calls.Dto;
using VolksCalls.Domain.Models.Calls.Request;
using VolksCalls.Domain.Models.Calls.Response;
using VolksCalls.Domain.Models.CallsPreferences;
using VolksCalls.Domain.Models.CI;
using VolksCalls.Domain.Repository;
using VolksCalls.Infra.CrossCutting;
using VolksCalls.Infra.CrossCutting.Documents;
using VolksCalls.Infra.CrossCutting.Emails;

namespace VolksCalls.Domain.Services
{
    public class CallsServices : BaseServiceEntity<CallsDomain>, ICallsServices
    {
        readonly IConfiguration _configuration;
        readonly IEMailService _iEMailService;
        readonly ICallsCategoryRepository _callsCategoryRepository;
        readonly IBaseConsultRepository<CIDomain> _repositoryConsultCI;
        readonly IBaseConsultRepository<CallFormDomain> _repositoryConsultCallForm;
        readonly IHostEnvironment _hostEnvironment;
        readonly ICallsPreferencesRepository _callsPreferencesRepository;

        readonly IMapper _mapper;


        readonly IHttpContextAccessor _httpContextAccessor;


        private readonly EmailCallOpenning _mailSettings;

        Dictionary<string, string> CompletionGroup;
        public CallsServices(LNotifications notifications,
                             IConfiguration configuration,
                             IHostEnvironment hostEnvironment,
                             IUser user,
                             ICallRepository callRepository,
                             IUnitOfWork unitOfWork,
                             IHttpContextAccessor httpContextAccessor,
                             IMapper mapper,
                             IUsersService usersService,
                             ICallsPreferencesRepository callsPreferencesRepository,
                             ILogger<CallsServices> logger,
                             ICallsCategoryRepository callsCategoryRepository,
                             IOptions<EmailCallOpenning> emailSettings,
                             IEMailService iEMailService
                             )
            : base(callRepository, user, notifications)
        {
            _configuration = configuration;
            _iEMailService = iEMailService;
            _mailSettings = emailSettings.Value;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _callsCategoryRepository = callsCategoryRepository;
            _hostEnvironment = hostEnvironment;
            _callsPreferencesRepository = callsPreferencesRepository;
            _repositoryConsultCI = _callsCategoryRepository.unitOfWork.GetRepository<CIDomain>();
            _repositoryConsultCallForm = _callsCategoryRepository.unitOfWork.GetRepository<CallFormDomain>();


            CompletionGroup = new Dictionary<string, string>()
            {
                { "VW", "SD-VW OPS Service Desk VW do Brasil" },
                { "AUDI", "SD-AUDI OPS Service Desk AUDI do Brasil" },
                { "MAN","SD-MAN OPS Service Desk MAN Latin America"},
                { "ANY","Ticket Application OPS Support VW do Brasil" }
            };
        }
        string GetTitleCallOpening(CallsOpeningRequest callsOpeningRequest)
        {
            return $"{callsOpeningRequest.Locality.GetAttributeDescription()} (Ala:{callsOpeningRequest.Ala.GetAttributeDescription()}|Andar:{callsOpeningRequest.Floor.GetAttributeDescription()}|{callsOpeningRequest.Side.GetAttributeDescription()}|{callsOpeningRequest.Column}) - {callsOpeningRequest.Title} AUTOATENDIMENTO VW ";
        }

        string GetCompletionGroup(CallsOpeningRequest callsOpeningRequest)
                    => (callsOpeningRequest.Locality == Locality.Jabaquara || callsOpeningRequest.Locality == Locality.JabaquaraCarnaubeiras)
            ? CompletionGroup.FirstOrDefault(x => x.Key == "MAN").Value : CompletionGroup.FirstOrDefault(x => x.Key == "VW").Value;


        async Task<(CIDomain, CallsCategoryDomain)> GetCategoryParentCI(Guid categoryParentCI)
        {
            var callsCategoryParentCI = (await _callsCategoryRepository._repositoryConsult.SearchAsync(x => x.Id == categoryParentCI)).FirstOrDefault();
            var ci = callsCategoryParentCI.CI;
            if (ci == null || (ci != null && !ci.Active))
            {
                ci = (await _repositoryConsultCI.SearchAsync(x => x.Active && x.DefaultCI == true)).FirstOrDefault();
            }
            return (ci, callsCategoryParentCI);
        }
        public async Task<CallsOpeningResponse> CallsOpeningAsync(CallsOpeningRequest callsOpeningRequest,
            List<IFormFile> files)
        {
            EmptyOldFiles();
            var respCallsOpeningResponse = new CallsOpeningResponse();
            var emailRequest = new EmailRequest();
            string patchFolderCalls = GetFolderCallsFiles();

            bool folderCalls = Convert.ToBoolean(_configuration.GetSection("CallsSend")?.Value ?? "false");
            var resultCiCategoryParentCI = await GetCategoryParentCI(callsOpeningRequest.CategoryParentCI);
            var callsCategoryParentCI = resultCiCategoryParentCI.Item2;
            var ci = resultCiCategoryParentCI.Item1;

            await TreatFormResponse(callsOpeningRequest);

            IsValidCi(ci);

            if (_lNotifications.Any())
                return respCallsOpeningResponse;

            await AddCall(callsOpeningRequest, files, folderCalls, ci);
            await UpdateInsertCallPreferences(callsOpeningRequest);

            var scCategory = string.Empty;
            scCategory = GetCategory(callsCategoryParentCI);

            await GetTxtAttachment(callsOpeningRequest, emailRequest, patchFolderCalls);

            emailRequest.ToEmails.AddRange(_mailSettings.ToEmails);
            emailRequest.Subject = _mailSettings.Subject;

            if (_mailSettings.IsBodyHtml)
                AddMethodMailHTML(callsOpeningRequest, emailRequest, ci, scCategory);
            else
                AddMethodText(callsOpeningRequest, emailRequest, ci, scCategory);

            emailRequest.Attachments = files;
            await _iEMailService.SendEmailsAsync(emailRequest, _mailSettings);
            return respCallsOpeningResponse;
        }

        string GetCategory(CallsCategoryDomain callsCategoryParentCI)
        {
            string scCategory;
            var patchArray = callsCategoryParentCI.Patch.Split('|');
            var choiceProblem = false;

            foreach (var pat in patchArray)
            {
                if (choiceProblem)
                    break;
                var patDelemiter = pat.Split('/');

                foreach (var pdelemiter in patDelemiter)
                {
                    choiceProblem = pdelemiter.ToLower().Trim().Contains("problema");
                    if (choiceProblem)
                        break;
                }

            }
            scCategory = choiceProblem == true ? "Incident" : "Request";
            return scCategory;
        }

  

        private async Task AddCall(CallsOpeningRequest callsOpeningRequest,
            List<IFormFile> files, bool folderCalls, CIDomain ci)
        {
            /*processo*/
            var call = _mapper.Map<CallsDomain>(callsOpeningRequest);
            call.CIId = ci.CIId;
            call.CIName = ci.CIName;
            call.CIQuee = ci.CallGroup;
            string patchFolderCallsSend = string.Empty;
            SetInsertEntity(call);

            if (files.Any() && folderCalls)
            {
                patchFolderCallsSend = System.IO.Path.Combine(GetFolderCallsFilesSend(), call.Id.ToString());
                if (!System.IO.Directory.Exists(patchFolderCallsSend))
                    System.IO.Directory.CreateDirectory(patchFolderCallsSend);
            }
            foreach (var file in files)
            {
                var archive = new ArchiveDomain();
                string strFileExtension = System.IO.Path.GetExtension(file.FileName);
                archive.FileName = file.FileName;
                archive.Extension = strFileExtension.Replace(".","").GetEnumToName<Extension>(Extension.noextension);
                archive.FileLocation = FileLocation.Folder;
                archive.Size = file.Length;
                archive.Path = patchFolderCallsSend;
                SetInsertEntity(archive);
                call.Archives.Add(archive);
                if (folderCalls)
                {
                    using (var stream = new FileStream(Path.Combine(patchFolderCallsSend, archive.Identity.ToString() + strFileExtension), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
            await AddAsync(call);
        }

        async Task TreatFormResponse(CallsOpeningRequest callsOpeningRequest)
        {
            if (!string.IsNullOrEmpty(callsOpeningRequest.CallFormId))
            {
                var isvalidForm = true;
                var formResponses = JsonConvert.DeserializeObject<Dictionary<string, string>>(callsOpeningRequest.ResponseCallForm);

                if (formResponses == null || (formResponses != null && formResponses.Count <= 0))
                {
                    isvalidForm = false;
                    _lNotifications.Add(new Notification { Message = " Atenção não foram identificadas respostas por favor verifique. " });
                }


                var callForm = (await _repositoryConsultCallForm.SearchAsync(x => x.Active && x.Id.ToString() == callsOpeningRequest.CallFormId)).FirstOrDefault();
                if (callForm == null)
                {
                    isvalidForm = false;
                    _lNotifications.Add(new Notification { Message = " Atenção não foi possível obter o formulário. " });
                }

                if (isvalidForm)
                {
                    callsOpeningRequest.Description += System.Environment.NewLine;
                    callsOpeningRequest.Description += $" Formulário:  {callForm.Name} ";
                    var activeQuestions = callForm.CallFormsQuestions.Where(x => x.Active).OrderBy(x => x.Order).ToList();
                    foreach (var questions in activeQuestions)
                    {
                        callsOpeningRequest.Description += System.Environment.NewLine;
                        callsOpeningRequest.Description += $" Pergunta: {questions.Label} ";
                        formResponses.TryGetValue(questions.Key, out string resp);
                        callsOpeningRequest.Description += System.Environment.NewLine;
                        if (!string.IsNullOrEmpty(resp))
                            callsOpeningRequest.Description += $" Resposta: {resp} ";
                        else
                            callsOpeningRequest.Description += $" Resposta: Não houve resposta ";
                    }
                }


            }
        }

        private async Task UpdateInsertCallPreferences(CallsOpeningRequest callsOpeningRequest)
        {
            var callPreference = (await _callsPreferencesRepository._repositoryConsult.SearchAsync(x => x.Active && x.UserId == callsOpeningRequest.UserId)).FirstOrDefault();
            if (callPreference == null)
            {
                var callsPreferences = _mapper.Map<CallCategoryDomain>(callsOpeningRequest);
                callsPreferences.Active = true;
                callsPreferences.DateRegister = DateTime.Now;
                callsPreferences.UserInsertedId = Guid.NewGuid();
                _callsPreferencesRepository.Add(callsPreferences);
            }
            else
            {
                callPreference.Ala = callsOpeningRequest.Ala;
                callPreference.UserId = callsOpeningRequest.UserId;
                callPreference.Telephone = callsOpeningRequest.Telephone;
                callPreference.CellPhone = callsOpeningRequest.CellPhone;
                callPreference.WorkSchedule = callsOpeningRequest.WorkSchedule;
                callPreference.Collaborator = callsOpeningRequest.Collaborator;
                callPreference.Locality = callsOpeningRequest.Locality;
                callPreference.Reference = callsOpeningRequest.Reference;
                callPreference.Ala = callsOpeningRequest.Ala;
                callPreference.Floor = callsOpeningRequest.Floor;
                callPreference.Side = callsOpeningRequest.Side;
                callPreference.HostName = callsOpeningRequest.HostName;
                callPreference.Column = callsOpeningRequest.Column;
                callPreference.NameContact = callsOpeningRequest.NameContact;
                callPreference.PhoneContact = callsOpeningRequest.PhoneContact;
                callPreference.EmailContact = callsOpeningRequest.EmailContact;
            }
          ;
        }

        private void AddMethodText(CallsOpeningRequest callsOpeningRequest, EmailRequest emailRequest, CIDomain ci, string scCategory)
        {
            StringBuilder strBody = new StringBuilder();
            strBody.AppendLine($@"SC_type:mailpmo");
            strBody.AppendLine($@"SC_category:{scCategory}");
            strBody.AppendLine($@"SC_subcategory:");
            strBody.AppendLine($@"SC_producttype:");
            strBody.AppendLine($@"SC_module:");
            strBody.AppendLine($@"SC_problemtype:");
            strBody.AppendLine($@"SC_vwlayer5:");

            strBody.AppendLine($@"SC_vw_ci_env:{ci.CIId}");
            strBody.AppendLine($@"SC_vw_ci_identification:{ci.CIId}");

            strBody.AppendLine($@"SC_assignment:{ci.CallGroup}");
            strBody.AppendLine($@"SC_system_impact:4");
            strBody.AppendLine($@"SC_extrefno:");
            strBody.AppendLine($@"SC_operator:{callsOpeningRequest.UserId}");
            strBody.AppendLine($@"SC_vw_completion_group:{GetCompletionGroup(callsOpeningRequest)}");
            strBody.AppendLine($@"SC_status:Open");
            //emailRequest.Body += $@"SC_status:Transferred<br/>";
            strBody.AppendLine($@"SC_reporttype:MailReader");
            strBody.AppendLine($@"SC_vw_ci_instance:{callsOpeningRequest.Locality.GetAttributeDescription()}");
            strBody.AppendLine($@"SC_email:{callsOpeningRequest.Email}");
            strBody.AppendLine($@"SC_title:{GetTitleCallOpening(callsOpeningRequest)}");
            strBody.AppendLine($@"SC_description:{callsOpeningRequest.Description}");

            emailRequest.Body += strBody.ToString();
        }

        void AddMethodMailHTML(CallsOpeningRequest callsOpeningRequest, EmailRequest emailRequest, CIDomain ci, string scCategory)
        {
            emailRequest.Body += $@"SC_type:mailpmo<br/>";
            emailRequest.Body += $@"SC_category:{scCategory}<br/>";
            emailRequest.Body += $@"SC_subcategory:<br/>";
            emailRequest.Body += $@"SC_producttype:<br/>";
            emailRequest.Body += $@"SC_module:<br/>";
            emailRequest.Body += $@"SC_problemtype:<br/>";
            emailRequest.Body += $@"SC_vwlayer5:<br/>";

            emailRequest.Body += $@"SC_vw_ci_env:{ci.CIId}<br/>";
            emailRequest.Body += $@"SC_vw_ci_identification:{ci.CIId}<br/>";

            emailRequest.Body += $@"SC_assignment:{ci.CallGroup}<br/>";
            emailRequest.Body += $@"SC_system_impact:4<br/>";
            emailRequest.Body += $@"SC_extrefno:<br/>";
            emailRequest.Body += $@"SC_operator:{callsOpeningRequest.UserId}<br/>";
            emailRequest.Body += $@"SC_vw_completion_group:{GetCompletionGroup(callsOpeningRequest)}<br/>";
            emailRequest.Body += $@"SC_status:Open<br/>";
            //emailRequest.Body += $@"SC_status:Transferred<br/>";
            emailRequest.Body += $@"SC_reporttype:MailReader<br/>";
            emailRequest.Body += $@"SC_vw_ci_instance:{callsOpeningRequest.Locality.GetAttributeDescription()}<br/>";
            emailRequest.Body += $@"SC_email:{callsOpeningRequest.Email}<br/>";
            emailRequest.Body += $@"SC_title:{GetTitleCallOpening(callsOpeningRequest)}<br/>";
            emailRequest.Body += $@"SC_description:{callsOpeningRequest.Description}<br/>";
        }

        void IsValidCi(CIDomain ci)
        {
            if (ci == null)
            {
                _lNotifications.Add(new Notification { Message = " Atenção não foi possível obter o CI da categoria. " });

            }

            if (string.IsNullOrEmpty(ci.CallGroup))
            {
                _lNotifications.Add(new Notification { Message = " Atenção não foi possível obter o Assignment . " });

            }
        }

        public async Task<CallsOpeningResponse> CallsOpeningAsync(CallsOpeningRequest callsOpeningRequest)
        {
            EmptyOldFiles();
            var respCallsOpeningResponse = new CallsOpeningResponse();
            var emailRequest = new EmailRequest();
            string patchFolderCalls = GetFolderCallsFiles();
            var resultCiCategoryParentCI = await GetCategoryParentCI(callsOpeningRequest.CategoryParentCI);
            var callsCategoryParentCI = resultCiCategoryParentCI.Item2;
            var ci = resultCiCategoryParentCI.Item1;

            IsValidCi(ci);

            if (_lNotifications.Any())
                return respCallsOpeningResponse;

            var scCategory = callsCategoryParentCI.Description.ToLower().Trim() == "Problema" ? "Incident" : "request";

            await GetTxtAttachment(callsOpeningRequest, emailRequest, patchFolderCalls);

            emailRequest.ToEmails.AddRange(_mailSettings.ToEmails);
            emailRequest.Subject = _mailSettings.Subject;

            StringBuilder strBody = new StringBuilder();
            strBody.AppendLine($@"SC_type:mailpmo");
            strBody.AppendLine($@"SC_category:{scCategory}");
            strBody.AppendLine($@"SC_subcategory:");
            strBody.AppendLine($@"SC_producttype:");
            strBody.AppendLine($@"SC_module:");
            strBody.AppendLine($@"SC_problemtype:");
            strBody.AppendLine($@"SC_vwlayer5:");

            strBody.AppendLine($@"SC_vw_ci_env:{ci.CIId}");
            strBody.AppendLine($@"SC_vw_ci_identification:{ci.CIId}");

            strBody.AppendLine($@"SC_assignment:{ci.CallGroup}");
            strBody.AppendLine($@"SC_system_impact:4");
            strBody.AppendLine($@"SC_extrefno:");
            strBody.AppendLine($@"SC_operator:{callsOpeningRequest.Name}");
            strBody.AppendLine($@"SC_vw_completion_group:{GetCompletionGroup(callsOpeningRequest)}");
            strBody.AppendLine($@"SC_status:Transferred");
            strBody.AppendLine($@"SC_reporttype:MailReader");
            strBody.AppendLine($@"SC_vw_ci_instance:{callsOpeningRequest.Locality.GetAttributeDescription()}");
            strBody.AppendLine($@"SC_email:{callsOpeningRequest.Email}");
            strBody.AppendLine($@"SC_title:{GetTitleCallOpening(callsOpeningRequest)}");
            strBody.AppendLine($@"SC_description:{callsOpeningRequest.Description}");

            emailRequest.Body += strBody.ToString();

            emailRequest.AttachmentsFiles.AddRange(callsOpeningRequest.CallOpeningFiles.Select(x => new Attachments
            {
                FileName = x.FileName,
                Path = Path.Combine(patchFolderCalls, x.Id + System.IO.Path.GetExtension(x.FileName))
            }));

            await _iEMailService.SendEmailsAsync(emailRequest, _mailSettings);
            return respCallsOpeningResponse;
        }

        async Task GetTxtAttachment(CallsOpeningRequest callsOpeningRequest, EmailRequest emailRequest, string patchFolderCalls)
        {

            var attachmenttxt = new Attachments();
            var fileNameSave = Guid.NewGuid().ToString() + ".txt";
            attachmenttxt.Path = Path.Combine(patchFolderCalls, fileNameSave);
            attachmenttxt.FileName = "Personaldata.txt";
            /**/
            List<string> linesTxt = new List<string>();
            linesTxt.Add(callsOpeningRequest.Description);
            linesTxt.Add("");
            linesTxt.Add($@"Hostname/IP: {callsOpeningRequest.HostName}");
            linesTxt.Add("");
            linesTxt.Add("------------------------------------------------------------------");
            linesTxt.Add("");
            linesTxt.Add(">> INFORMAÇÕES DO SOLICITANTE");
            linesTxt.Add($@"Nome: {callsOpeningRequest.Name}");
            linesTxt.Add($@"User ID: {callsOpeningRequest.UserId}");
            linesTxt.Add($@"Chapa: {callsOpeningRequest.Plate}");
            var isVip = callsOpeningRequest.Vip ? "Sim" : "Não";
            linesTxt.Add($@"VIP: {isVip}");
            linesTxt.Add($@"Telefone: {callsOpeningRequest.Telephone}");
            linesTxt.Add($@"Celular: {callsOpeningRequest.CellPhone}");
            linesTxt.Add($@"E-mail: {callsOpeningRequest.Email}");
            linesTxt.Add($@"Horário de Trabalho: {callsOpeningRequest.WorkSchedule.GetAttributeDescription()}");
            linesTxt.Add($@"Localidade: {callsOpeningRequest.Locality.GetAttributeDescription()}");
            linesTxt.Add($@"Ala: {callsOpeningRequest.Ala.GetAttributeDescription()}");
            linesTxt.Add($@"Andar: {callsOpeningRequest.Floor.GetAttributeDescription()}");
            linesTxt.Add($@"Lado: {callsOpeningRequest.Side.GetAttributeDescription()}");
            linesTxt.Add($@"Coluna: {callsOpeningRequest.Column}");
            linesTxt.Add("");
            linesTxt.Add("------------------------------------------------------------------");
            linesTxt.Add("");
            linesTxt.Add(">> CONTATO ALTERNATIVO");
            linesTxt.Add($@"Nome: {callsOpeningRequest.NameContact}");
            linesTxt.Add($@"Telefone: {callsOpeningRequest.PhoneContact}");
            linesTxt.Add($@"E-mail: {callsOpeningRequest.EmailContact}");
            linesTxt.Add("");

            await File.WriteAllLinesAsync(attachmenttxt.Path, linesTxt);
            emailRequest.AttachmentsFiles.Add(attachmenttxt);


        }

        public async Task<SendFilesToCallsResponse> SendFilesToCallsAsync(List<IFormFile> files)
        {
            string patchFolderCalls = GetFolderCallsFiles();

            var responseSendFilesToCalls = new SendFilesToCallsResponse();
            foreach (var file in files)
            {
                var fileAdd = new SendFilesToCallsDto();
                fileAdd.FileName = file.FileName;
                responseSendFilesToCalls.SendFiles.Add(fileAdd);
                string strFileExtension = System.IO.Path.GetExtension(file.FileName);
                using (var stream = new FileStream(Path.Combine(patchFolderCalls, fileAdd.Id.ToString() + strFileExtension), FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            return responseSendFilesToCalls;
        }


        void EmptyOldFiles()
        {

            var patchCallsFiles = GetFolderCallsFiles();
            DirectoryInfo d = new DirectoryInfo(patchCallsFiles);
            var filesDelete = d.GetFiles().Where(x => DateTime.Now.Subtract(x.LastWriteTime).Days > 5);
            foreach (FileInfo item in filesDelete)
                item.Delete();

        }




        string GetFolderCallsFilesSend()
        {
            var folderCalls = _configuration.GetSection("PatchFilesCallsSend")?.Value;
            string patchFolderCalls = Path.Combine(_hostEnvironment.ContentRootPath, folderCalls);
            if (!System.IO.Directory.Exists(patchFolderCalls))
                System.IO.Directory.CreateDirectory(patchFolderCalls);
            return patchFolderCalls;
        }
        string GetFolderCallsFiles()
        {
            var folderCalls = _configuration.GetSection("PatchFilesCalls")?.Value;
            string patchFolderCalls = Path.Combine(_hostEnvironment.ContentRootPath, folderCalls);
            if (!System.IO.Directory.Exists(patchFolderCalls))
                System.IO.Directory.CreateDirectory(patchFolderCalls);
            return patchFolderCalls;
        }

        public async Task OpenMail()
        {
            throw new NotImplementedException();
        }

        public Task OpenMail(CallsOpeningRequest callsOpeningRequest)
        {
            throw new NotImplementedException();
        }
    }
}
