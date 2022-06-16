using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.UI.Controllers
{
    public class TuitorController : Controller
    {
        private readonly SchoolContext _context;

        public TuitorController(SchoolContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
