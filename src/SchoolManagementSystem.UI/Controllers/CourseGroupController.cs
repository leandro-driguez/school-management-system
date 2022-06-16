using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.UI.Controllers
{
    public class CourseGroupController : Controller
    {
        private readonly SchoolContext _context;

        public CourseGroupController(SchoolContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
