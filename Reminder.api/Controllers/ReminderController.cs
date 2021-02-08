using Microsoft.AspNetCore.Mvc;
using Reminder.api.Dtos;
using Reminder.api.Models;
using Reminder.api.Repositories;
using System;
using System.Threading.Tasks;

namespace Reminder.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReminderController : Controller
    {
        private readonly IReminderRepository _repo;
        private readonly IUnitOfWork _unitOfWork;

        public ReminderController(IReminderRepository repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAll());

        [HttpGet("due")]
        public IActionResult GetAllDue() => Ok(_repo.GetAllDue());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReminder(Guid id)
        {
            var reminder = await _repo.GetbyId(id);
            if (reminder == null)
            {
                return NotFound();
            }
            return Ok(reminder);
        }

        [HttpPost]
        public async Task<IActionResult> AddReminder(AddReminderDto addReminderDto)
        {
            var reminderToAdd = new ReminderModel()
            {
                Title = addReminderDto.Title,
                Description = addReminderDto.Description,
                DueDate = addReminderDto.DueDate
            };

            var createdReminder = await _repo.Add(reminderToAdd);
            await _unitOfWork.Commit();
            return Created("Reminder", createdReminder.Id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReminder(Guid id)
        {
            try
            {
                await _repo.Delete(id);
            }
            catch
            {
                return NotFound();
            }
            await _repo.Delete(id);

            await _unitOfWork.Commit();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReminder(UpdateReminderDto updateReminderDto)
        {
            var reminderToUpdate = await _repo.GetbyId(updateReminderDto.Id);
            if (reminderToUpdate == null)
            {
                return NotFound();
            }

            reminderToUpdate.Title = updateReminderDto.Title;
            reminderToUpdate.Description = updateReminderDto.Description;
            reminderToUpdate.DueDate = updateReminderDto.DueDate;
            reminderToUpdate.Sent = updateReminderDto.Sent;

            await _unitOfWork.Commit();
            return NoContent();
        }
    }
}