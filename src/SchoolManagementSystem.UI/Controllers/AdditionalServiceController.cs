using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.UI.Models;

namespace SchoolManagementSystem.UI.Controllers
{
    public class AdditionalServiceController : Controller
    {
        private readonly SchoolContext _context;

        public AdditionalServiceController(SchoolContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
