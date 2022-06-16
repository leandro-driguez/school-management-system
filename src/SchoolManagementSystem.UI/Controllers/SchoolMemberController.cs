using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.UI.Controllers
{
    public class SchoolMemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
