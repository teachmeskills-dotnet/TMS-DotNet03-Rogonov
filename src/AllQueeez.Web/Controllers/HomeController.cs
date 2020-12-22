using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllQueez.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return User.Identity.IsAuthenticated
                ? RedirectToAction(nameof(App))
                : (IActionResult)RedirectPermanent("/account/login");
        }

        [Authorize]
        public IActionResult App()
        {
            return View();
        }
    }
}