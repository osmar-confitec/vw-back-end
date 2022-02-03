using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Interfaces;
using VolksCalls.Domain.Models.Evidences.Request;
using VolksCalls.Domain.Models.Evidences.Response;
using VolksCalls.Infra.CrossCutting;
using VolksCalls.Infra.CrossCutting.Emails;

namespace VolksCalls.Domain.Services
{
    public class EvidenceService : BaseService, IEvidenceService
    {

        readonly IConfiguration _configuration;
        readonly IEMailService _iEMailService;
        readonly IHostEnvironment _hostEnvironment;
        readonly EmailSendEvidences _mailSettings;
        readonly IUser _user;
        public EvidenceService(IEMailService iEMailService,
                               IOptions<EmailSendEvidences> emailSettings,
                               IUser user,
                               IHostEnvironment hostEnvironment,
                               IConfiguration configuration,
                               LNotifications lNotifications)
            : base(lNotifications)
        {
            _user = user;
            _configuration = configuration;
            _iEMailService = iEMailService;
            _hostEnvironment = hostEnvironment;
            _mailSettings = emailSettings.Value;

        }


        string GetFolderSendEvidenceFiles()
        {
            var folderCalls = _configuration.GetSection("PatchFilesSendEvidence")?.Value;
            string patchFolderCalls = Path.Combine(_hostEnvironment.ContentRootPath, folderCalls);
            if (!System.IO.Directory.Exists(patchFolderCalls))
                System.IO.Directory.CreateDirectory(patchFolderCalls);
            return patchFolderCalls;
        }

        public async Task<SendEvidencesResponse> SendEvidencesAsync(SendEvidencesRequest sendEvidencesRequest, List<IFormFile> files)
        {

            var sendEvidencesSendEmail = string.IsNullOrEmpty(_configuration.GetSection("SendEvidencesSendEmail")?.Value) ? false : Convert.ToBoolean(_configuration.GetSection("SendEvidencesSendEmail").Value);
            var sendEvidencesSavePatch = string.IsNullOrEmpty(_configuration.GetSection("SendEvidencesSavePatch")?.Value) ? false : Convert.ToBoolean(_configuration.GetSection("SendEvidencesSavePatch").Value);

            if (sendEvidencesSendEmail)
            {
                StringBuilder strBody = new StringBuilder();
                var emailRequest = new EmailRequest();
                emailRequest.ToEmails.AddRange(_mailSettings.ToEmails);
                emailRequest.Subject = $@"VW - Envio de Evidência - Requisição {sendEvidencesRequest.RequestNumber} - AUTOATENDIMENTO VW";
                strBody.AppendLine($@"");
                strBody.AppendLine($@"Prezado Service Desk,");
                strBody.AppendLine($@"Seguem anexos arquivos para evidência da requisição {sendEvidencesRequest.RequestNumber}.");
                strBody.AppendLine($@"Arquivos enviados pelo perfil {_user.Name}, através do computador {sendEvidencesRequest.HostName}.");
                strBody.AppendLine($@"Informações adicionais enviadas pelo usuário:{sendEvidencesRequest.InfoAditional}");
                strBody.AppendLine($@"");
                strBody.AppendLine($@"Este e-mail foi enviado via App Service Desk.");
                emailRequest.Body += strBody.ToString();
                emailRequest.Attachments = files;
                await _iEMailService.SendEmailsAsync(emailRequest, _mailSettings);
              
            }
            if (sendEvidencesSavePatch)
            {
                string patchFolderSendEvidence = GetFolderSendEvidenceFiles();
                patchFolderSendEvidence = Path.Combine(patchFolderSendEvidence,$"{DateTime.Now.Ticks.ToString()}-{sendEvidencesRequest.RequestNumber}");
                if (!System.IO.Directory.Exists(patchFolderSendEvidence))
                    System.IO.Directory.CreateDirectory(patchFolderSendEvidence);

                foreach (var file in files)
                {
                    using (var stream = new FileStream(Path.Combine(patchFolderSendEvidence, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                List<string> linesTxt = new List<string>();
                linesTxt.Add(sendEvidencesRequest.InfoAditional ?? "");
                await File.WriteAllLinesAsync(Path.Combine(patchFolderSendEvidence, "SendEvidencesRequest.txt"), linesTxt);

            }
            return new SendEvidencesResponse();

        }
    }
}
