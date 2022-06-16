using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.UI.Controllers
{
    public class BasicMeanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
