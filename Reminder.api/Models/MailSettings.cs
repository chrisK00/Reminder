using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reminder.api.Models
{
    public class MailSettings
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string SmtpHost { get; set; }
    }
}
