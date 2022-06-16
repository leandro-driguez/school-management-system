using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.UI.Controllers
{
    public class CourseController : Controller
    {
        private readonly SchoolContext _context;

        public CourseController(SchoolContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
