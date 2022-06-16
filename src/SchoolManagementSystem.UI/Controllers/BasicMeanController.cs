using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.UI.Controllers
{
    public class BasicMeanController : Controller
    {
        private readonly SchoolContext _context;

        public BasicMeanController(SchoolContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
