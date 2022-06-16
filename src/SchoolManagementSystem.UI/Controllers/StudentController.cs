using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.UI.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
