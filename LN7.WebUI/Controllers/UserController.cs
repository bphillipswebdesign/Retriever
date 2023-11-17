using LN7.BL;
using LN7.BL.Models;
using LN7.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Numerics;

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
        public ActionResult Create(User user)
        {
            try
            {
                UserManager.Insert(user);
                return RedirectToAction(nameof(Login));
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

        //LOCAL LOGIN

        [HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(User user)
        //{
        //    try
        //    {
        //        if (UserManager.Login(user))
        //        {
        //            // Successful login
        //            SetUser(user);
        //            if (TempData["returnurl"] != null)
        //                return Redirect(TempData["returnurl"]?.ToString());
        //            else
        //                return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            return View(user);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Error = ex.Message;
        //        return View(user);
        //    }
        //}

        //REMOTE LOGIN

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://ln7.azurewebsites.net/api/");
                string serializedObject = JsonConvert.SerializeObject(user);
                var content = new StringContent(serializedObject);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = client.PostAsync("User" + "/", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    // set up var from response
                    var body = response.Content.ReadAsStringAsync().Result;
                    User player = JsonConvert.DeserializeObject<User>(body);
                    Guid userId = player.Id;
                    //set up client to get full user

                    //get user through second request
                    string userString = client.GetStringAsync("User/" + userId).Result;
                    user = JsonConvert.DeserializeObject<User>(userString);

                    //set user
                    SetUser(user);

                    if (TempData["returnuri"] != null)
                        return Redirect(TempData["returnuri"]?.ToString());
                    else
                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Login Failed";
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