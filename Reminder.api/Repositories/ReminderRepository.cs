using Microsoft.EntityFrameworkCore;
using Reminder.api.Data;
using Reminder.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reminder.api.Repositories
{
    public class ReminderRepository : IReminderRepository
    {
        private readonly DataContext _context;

        public ReminderRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<ReminderModel> Add(ReminderModel reminder)
        {
            await _context.Reminders.AddAsync(reminder);
            return reminder;
        }

        public async Task Delete(Guid id)
        {
            var reminder = await GetbyId(id);
            if (reminder == null)
            {
                throw new ArgumentException();
            }
            _context.Reminders.Remove(reminder);
        }

        public async Task<IEnumerable<ReminderModel>> GetAll() => await _context.Reminders.ToArrayAsync();
        public IEnumerable<ReminderModel> GetAllDue()
        {
            return _context.Reminders
                .Where(r => r.DueDate <= DateTime.Now)
                .Where(r => !r.Sent);
        }

        public async Task<ReminderModel> GetbyId(Guid id) => await _context.Reminders.FirstOrDefaultAsync(r => r.Id == id);

    }
}
