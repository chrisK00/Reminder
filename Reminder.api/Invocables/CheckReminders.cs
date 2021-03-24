using System;
using System.Threading.Tasks;
using Coravel.Invocable;
using Coravel.Mailer.Mail.Interfaces;
using Microsoft.Extensions.Logging;
using Reminder.api.Models;
using Reminder.api.Repositories;

namespace Reminder.api.Invocables
{
    public class CheckReminders : IInvocable
    {
        private readonly IMailer _mailer;
        private readonly ILogger _logger;
        private readonly IReminderRepository _repo;

        public CheckReminders(IReminderRepository repo, IMailer mailer
            , ILogger<CheckReminders> logger)
        {
            _repo = repo;
            _mailer = mailer;
            _logger = logger;
        }

        public async Task Invoke()
        {
            foreach (var item in _repo.GetAllDue())
            {
                if (item.DueDate <= DateTime.Now && !item.Sent)
                {
                    try
                    {
                        await _mailer.SendAsync(new ReminderMailable(item));
                        item.Sent = true;
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e.Message, e);
                    }                   
                }
            }
        }
    }
}