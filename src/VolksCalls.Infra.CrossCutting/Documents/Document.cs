using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Infra.CrossCutting.Documents
{
   public abstract class Document
    {
        protected string Patch { get; private set; }

        public readonly LNotifications notifications;
        protected Document(LNotifications _notifications, string patch)
        {
            notifications = _notifications ?? new LNotifications();
            if (!System.IO.File.Exists(patch))
                notifications.Add(new Notification { Message  = "Atenção arquivo não existe." });
            Patch = patch;
        }
    }
}
