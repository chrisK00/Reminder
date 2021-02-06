using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reminder.api.Models;

namespace Reminder.api.Repositories
{
    public class ReminderRepository
    {
        private readonly List<ReminderModel> _reminders = new()
        {
            new ReminderModel()
            { Title = "Hämta barnen", Description = "Glöm inte vantarna", DueDate = DateTime.Now.AddDays(-1) },
            new ReminderModel()
            { Title = "Mata ormen", Description = "", DueDate = DateTime.Now.AddDays(2) },
            new ReminderModel()
            { Title = "STÄDA RUMMET", Description = "gör det fint :D", DueDate = DateTime.Now.AddDays(-5), Sent = true }
        };

        public IEnumerable<ReminderModel> GetAllDueReminders()
        {

            return _reminders
                .Where(r => r.DueDate <= DateTime.Now)
                .Where(r => !r.Sent);
        }
    }
}
