using Reminder.api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reminder.api.Repositories
{
    public interface IReminderRepository
    {
        Task<IEnumerable<ReminderModel>> GetAll();

        Task<ReminderModel> GetbyId(Guid id);

        Task<ReminderModel> Add(ReminderModel reminder);

        Task Delete(Guid id);

        IEnumerable<ReminderModel> GetAllDue();
    }
}