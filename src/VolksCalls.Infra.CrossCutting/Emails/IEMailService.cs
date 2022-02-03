using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VolksCalls.Infra.CrossCutting.Emails
{
   public interface IEMailService
    {

        Task SendEmailsAsync(EmailRequest emailRequest, EmailSettings emailSettings);

    }
}
