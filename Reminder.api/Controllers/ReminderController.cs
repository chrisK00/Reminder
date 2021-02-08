using Microsoft.AspNetCore.Mvc;
using Reminder.api.Models;
using Reminder.api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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


    }
}
