using System;

namespace Reminder.api.Models
{
    public class ReminderModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Sent { get; set; }
    }
}