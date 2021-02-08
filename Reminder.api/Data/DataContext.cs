using Microsoft.EntityFrameworkCore;
using Reminder.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
