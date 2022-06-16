using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.UI.Controllers
{
    public class CourseGroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
