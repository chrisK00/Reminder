using Microsoft.EntityFrameworkCore;
using Reminder.api.Models;

namespace Reminder.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ReminderModel> Reminders { get; set; }
    }
}