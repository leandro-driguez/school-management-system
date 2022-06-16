using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.UI.Controllers
{
    public class ResourceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
