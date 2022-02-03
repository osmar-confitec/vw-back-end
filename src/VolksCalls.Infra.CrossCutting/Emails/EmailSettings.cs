using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Infra.CrossCutting.Emails
{
   public abstract class EmailSettings
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Subject { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int? Port { get; set; }

        public string SmtpDeliveryMethod { get; set; }

        public string UserName { get; set; }

        public bool IsBodyHtml { get; set; }

        public bool EnableSsl { get; set; }

        public bool UseDefaultCredentials { get; set; }
        public List<string> ToEmails { get; set; }

        protected EmailSettings()
        {
            ToEmails = new List<string>();
        }
    }
}

