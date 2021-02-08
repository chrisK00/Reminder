using System.Threading.Tasks;

namespace Reminder.api.Repositories
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}