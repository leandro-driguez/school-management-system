using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.UI.Controllers
{
    public class EntityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
