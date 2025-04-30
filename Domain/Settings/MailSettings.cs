using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Settings
{
    //MailSettings
    public class MailSettings
    {
        // EmailFrom is the sender's email address
        public string EmailFrom { get; set; }

        // SmtpHost is the SMTP server address
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        // SmtpUser is the sender's email address

        public string SmtpUser { get; set; }
        public string SmtpPass { get; set; }
        public string DisplayName { get; set; }
    }
}

