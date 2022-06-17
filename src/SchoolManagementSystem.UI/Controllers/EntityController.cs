using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.UI.Models;

namespace SchoolManagementSystem.UI.Controllers
{
    public class EntityController : Controller
    {
        private readonly IRepository<Entity> _repository;

        public EntityController(IRepository<Entity> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
