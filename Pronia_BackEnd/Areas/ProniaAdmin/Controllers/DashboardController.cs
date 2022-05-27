using Microsoft.AspNetCore.Mvc;

namespace Pronia_BackEnd.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    public class DashboardController : Controller
    { 
        public ActionResult Index()
        {
            return View();
        }
    }
}
