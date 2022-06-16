using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.UI.Controllers
{
    public class WorkerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
