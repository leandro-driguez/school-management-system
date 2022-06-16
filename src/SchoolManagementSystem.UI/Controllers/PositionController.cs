using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.UI.Controllers
{
    public class PositionController : Controller
    {
        private readonly SchoolContext _context;

        public PositionController(SchoolContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
