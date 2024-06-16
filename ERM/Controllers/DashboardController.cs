using Microsoft.AspNetCore.Mvc;

namespace ERM.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
