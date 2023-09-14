using LN7.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LN7.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (Authenticate.IsAuthenticated(HttpContext))
            {
                ViewBag.Error = TempData["error"];
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
