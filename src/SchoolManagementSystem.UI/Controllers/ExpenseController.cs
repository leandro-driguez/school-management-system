using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.UI.Controllers
{
    public class ExpenseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
