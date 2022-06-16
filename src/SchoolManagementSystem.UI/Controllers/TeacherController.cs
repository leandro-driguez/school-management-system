using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.UI.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
