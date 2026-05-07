using Microsoft.AspNetCore.Mvc;

namespace UniManage.Controllers
{
    public class LandingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
