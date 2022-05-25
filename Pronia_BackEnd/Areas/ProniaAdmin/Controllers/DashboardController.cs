using Microsoft.AspNetCore.Mvc;

namespace Pronia_BackEnd.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAmdin")]
    public class DashboardController : Controller
    { 
        public IActionResult Index()
        {
            return View();
        }
    }
}
