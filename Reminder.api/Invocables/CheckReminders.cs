using Coravel.Invocable;
using Reminder.api.Repositories;
using Reminder.api.Services;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Reminder.api.Invocables
{
    public class CheckReminders : IInvocable
    {
        private readonly IReminderRepository _repo;
        private readonly MailService _mailService;

        public CheckReminders(IReminderRepository repo, MailService mailService)
        {
            _repo = repo;
            _mailService = mailService;
        }

        public async Task Invoke()
        {
            foreach (var item in _repo.GetAllDue())
            {
                if (item.DueDate <= DateTime.Now && !item.Sent)
                {
                    Console.WriteLine($"Time to do: {item.Title}");
                    var sent = await _mailService.SendMail(
                        new MailAddress("christianhunter707@gmail.com"),
                        item.Title,
                        item.Description);
                    if (sent)
                    {
                        item.Sent = true;
                    }
                }
            }
        }
    }
}