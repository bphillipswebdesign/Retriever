using LN7.BL;
using LN7.BL.Models;
using LN7.WebUI.Models;
using LN7.WebUI.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;

namespace LN7.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
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
        public ActionResult Create(DogVM dogVM, IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    // Define the path where you want to save the file in wwwroot/images
                    var uploadsFolder = ("../wwwroot/images");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    // Set the Dog.Imagepath to the path of the saved image
                    dogVM.Dog.Imagepath = "images/" + uniqueFileName;
                }

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
            return View(dogVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DogVM dogVM)
        {
            try
            {
                DogManager.Delete(id);
                DogManager.Insert(dogVM.Dog);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Title = "Delete";
                return View();
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

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                // Define the path to save the file in wwwroot/images
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return RedirectToAction("Index");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}