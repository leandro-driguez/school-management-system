using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.UI.Models;

namespace SchoolManagementSystem.UI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IRepository<Student> _repository;

        public StudentController(IRepository<Student> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
