using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.UI.Models;

namespace SchoolManagementSystem.UI.Controllers
{
    public class WorkerController : Controller
    {
        private readonly IRepository<Worker> _repository;

        public WorkerController(IRepository<Worker> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
