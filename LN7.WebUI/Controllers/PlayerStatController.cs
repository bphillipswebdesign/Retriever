using LN7.BL;
using LN7.BL.Models;
using LN7.WebUI.Models;
using LN7.WebUI.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LN7.WebUI.Controllers
{
    public class PlayerStatController : Controller
    {
        private readonly ILogger<PlayerStatController> _logger;

        public PlayerStatController(ILogger<PlayerStatController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Index";
            return View(PlayerStatManager.Load());
        }  

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}