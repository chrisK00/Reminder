using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coravel.Mailer.Mail;

namespace Reminder.api.Models
{
    public class ReminderMailable : Mailable<ReminderMailable>
    {
        private readonly ReminderModel _reminderModel;
        public ReminderMailable(ReminderModel reminderModel)
        {
            _reminderModel = reminderModel;
        }
        public override void Build()
        {
            To("reciever@gmail.com")
                .From("sender@gmail.com")
                .Subject(_reminderModel.Title)
                .Html(_reminderModel.Description);                
        }
    }
}
