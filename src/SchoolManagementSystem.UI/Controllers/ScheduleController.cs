using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.UI.Controllers
{
    public class ScheduleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
