using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Application.Interfaces;
using VolksCalls.Domain.Interfaces;
using VolksCalls.Domain.Models.Evidences.Request;
using VolksCalls.Domain.Models.Evidences.Response;
using VolksCalls.Domain.Repository;
using VolksCalls.Infra.CrossCutting;
using VolksCalls.Infra.CrossCutting.Emails;

namespace VolksCalls.Application.Services
{
    public class EvidenceApplication : BaseApplication, IEvidenceApplication
    {

        readonly IEvidenceService _evidenceService;
        readonly IEMailService _iEMailService;
        readonly EmailSendEvidences _mailSettings;
        public EvidenceApplication(IEvidenceService evidenceService,

            IEMailService iEMailService,
                               IOptions<EmailSendEvidences> emailSettings,
            IUnitOfWork _unitOfWork, LNotifications _LNotifications) 
                        : base(_unitOfWork, _LNotifications)
        {
            _evidenceService = evidenceService;
            _iEMailService = iEMailService;
            _mailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync()
        {
            StringBuilder strBody = new StringBuilder();
            var emailRequest = new EmailRequest();
            emailRequest.ToEmails.AddRange(_mailSettings.ToEmails);
            emailRequest.Subject = $@"VW - Envio de Evidência - Requisição  AUTOATENDIMENTO VW";
            emailRequest.Body += strBody.ToString();
            await _iEMailService.SendEmailsAsync(emailRequest, _mailSettings);
        }

        public async Task<SendEvidencesResponse> SendEvidencesAsync(string sendEvidencesRequest, List<IFormFile> files)
                 => await _evidenceService.SendEvidencesAsync(JsonConvert.DeserializeObject<SendEvidencesRequest>(sendEvidencesRequest), files);
    }
}

