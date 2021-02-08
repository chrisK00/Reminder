using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reminder.api.Repositories
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
