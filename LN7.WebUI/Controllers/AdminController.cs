using LN7.BL;
using LN7.WebUI.Models;
using LN7.WebUI.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LN7.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Index";
            return View();
        }

        public ActionResult DogAdded()
        {
            ViewBag.Title = "Index";
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Create Dog";
            DogVM dogVM = new DogVM();
            return View(dogVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DogVM dogVM)
        {
            try
            {
                DogManager.Insert(dogVM.Dog);
                return RedirectToAction(nameof(DogAdded));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Title = "Create Dog";
                return View(dogVM);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}