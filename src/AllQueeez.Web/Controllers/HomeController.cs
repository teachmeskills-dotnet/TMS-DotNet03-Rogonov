using Microsoft.AspNetCore.Mvc;

namespace AllQueez.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
