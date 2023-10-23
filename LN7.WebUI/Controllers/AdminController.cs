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
            return View(DogManager.Load());
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

        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";
            DogVM dogVM = new DogVM(id);
            HttpContext.Session.SetObject("Id", dogVM.Dog.Id);
            return View(dogVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DogVM dogVM)
        {
            try
            {
                DogManager.Update(dogVM.Dog);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Title = "Edit";
                return View(dogVM);
            }
        }

        public ActionResult Details(int id)
        {
            ViewBag.Title = "Edit";
            DogVM dogVM = new DogVM(id);
            HttpContext.Session.SetObject("Id", dogVM.Dog.Id);
            return View(dogVM);
        }

        public ActionResult Delete(int id)
        {
            ViewBag.Title = "Delete";
            return View(DogManager.LoadById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, BL.Models.Dog dog)
        {
            try
            {
                DogManager.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Title = "Delete";
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}