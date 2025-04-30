using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Email
{
    public class EmailRequest
    {
        // To is the email address of the recipient
        public string To { get; set; }
        // Subject is the subject of the email
        public string Subject { get; set; }

        // Body is the body of the email
        public string Body { get; set; }

        // From is the email address of the sender
        public string From { get; set; } = null;
    }
}
