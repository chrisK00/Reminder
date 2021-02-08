using Reminder.api.Data;
using System.Threading.Tasks;

namespace Reminder.api.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public async Task Commit() => await _context.SaveChangesAsync();
    }
}
