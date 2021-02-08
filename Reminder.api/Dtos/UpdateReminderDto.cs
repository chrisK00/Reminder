using System;
using System.ComponentModel.DataAnnotations;

namespace Reminder.api.Dtos
{
    public class UpdateReminderDto
    {
        public Guid Id { get; set; }

        [MinLength(1)]
        public string Title { get; set; }

        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Sent { get; set; }
    }
}