using LN7.BL;
using LN7.BL.Models;
using LN7.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LN7.WebUI.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Signup(string returnUri)
        {
            TempData["returnuri"] = returnUri;
            return View();
        }

        public IActionResult Logout()
        {
            SetUser(null);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LN7.BL.Models.User user)
        {
            try
            {
                UserManager.Insert(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private void SetUser(User? user)
        {
            HttpContext.Session.SetObject("user", user);

            if (user != null)
            {
                HttpContext.Session.SetObject("fullname", "Welcome " + user.First_Name + " " + user.Last_Name);
            }
            else
            {
                HttpContext.Session.SetObject("fullname", string.Empty);
            }
        }

        public ActionResult Login(string returnUri)
        {
            TempData["returnuri"] = returnUri;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            try
            {
                if (UserManager.Login(user))
                {
                    // Successful login
                    SetUser(user);
                    if (TempData["returnurl"] != null)
                        return Redirect(TempData["returnurl"]?.ToString());
                    else
                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(user);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(user);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
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