using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Infra.CrossCutting.Emails
{

    public class Attachments
    {

        public string Path { get; set; }

        public string FileName { get; set; }

    }
    public class EmailRequest
    {
        public List<string> ToEmails { get; set; }
        public List<string> CCEmails { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
        public List<Attachments> AttachmentsFiles { get; set; }



        public EmailRequest()
        {
            ToEmails = new List<string>();
            CCEmails = new List<string>();
            AttachmentsFiles = new List<Attachments>();
        }
    }
}
