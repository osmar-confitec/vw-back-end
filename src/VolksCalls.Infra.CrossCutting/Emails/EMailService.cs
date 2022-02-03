using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace VolksCalls.Infra.CrossCutting.Emails
{
   public class EMailService : IEMailService
    {
        
        public EMailService()
        {
            
        }
        public async Task SendEmailsAsync(EmailRequest mailRequest, EmailSettings emailSettings)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            message.From = new MailAddress(emailSettings.Mail, emailSettings.DisplayName);
            foreach (var emailTo in mailRequest.ToEmails)
            {
                message.To.Add(new MailAddress(emailTo));
            }

            message.Subject = mailRequest.Subject;

            if (mailRequest.Attachments != null)
            {
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            Attachment att = new Attachment(new MemoryStream(fileBytes), file.FileName);
                            message.Attachments.Add(att);
                        }
                    }
                }
            }


            if (mailRequest.AttachmentsFiles != null)
            {
                foreach (var file in mailRequest.AttachmentsFiles)
                {
                    var fileBytes = await System.IO.File.ReadAllBytesAsync(file.Path);
                    Attachment att = new Attachment(new MemoryStream(fileBytes), file.FileName);
                    message.Attachments.Add(att);
                }
            }

            
            message.IsBodyHtml = emailSettings.IsBodyHtml;
            message.Body = mailRequest.Body;
            if (emailSettings.Port.HasValue)
            smtp.Port = emailSettings.Port.Value;

            smtp.Host = emailSettings.Host;
            smtp.EnableSsl = emailSettings.EnableSsl;
            smtp.UseDefaultCredentials = emailSettings.UseDefaultCredentials;
            if (!string.IsNullOrEmpty(emailSettings.UserName) && !string.IsNullOrEmpty(emailSettings.Password))
              smtp.Credentials = new NetworkCredential(emailSettings.UserName, emailSettings.Password);
            smtp.DeliveryMethod = emailSettings.SmtpDeliveryMethod.GetEnumToName<SmtpDeliveryMethod>(SmtpDeliveryMethod.Network);
            await smtp.SendMailAsync(message);
        }
    }
}
