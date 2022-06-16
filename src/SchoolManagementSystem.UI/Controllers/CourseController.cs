using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.UI.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
