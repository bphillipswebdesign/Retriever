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
            //User user = HttpContext.Session.Get<User>("user");
            var model = this.GetPartialData("My History");
            return View(model);           
        }  

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<PlayerStatVM> GetPartialData (string? btnFilter = null)
        {
            User user = HttpContext.Session.Get<User>("user");
            List<PlayerStatVM> playerStatVM = new List<PlayerStatVM>();

            switch (btnFilter)
            {
                case "My History":
                    playerStatVM = Load(PlayerStatManager.Load(user.Username));
                    return playerStatVM;
                case "All Games Today":
                    playerStatVM = Load(PlayerStatManager.Load(DateTime.Now));
                    return playerStatVM;
                case "All Games":
                    playerStatVM = Load(PlayerStatManager.Load());
                    return playerStatVM;                
                default:
                    return playerStatVM;
            }
        }

        [HttpGet]
        public ActionResult GetPlayerStats (string btnFilter) 
        {
        var model = this.GetPartialData(btnFilter);
            return PartialView("_PlayerStatPartial",model);
        }

        public List<PlayerStatVM> Load(List<BL.Models.PlayerStat> playerStat)
        {            
            List<PlayerStatVM> vm = new List<PlayerStatVM>();
            foreach(BL.Models.PlayerStat p in playerStat)
            {
                PlayerStatVM playerStat1 = new PlayerStatVM();
                playerStat1.Id = p.Id;
                playerStat1.UserId = p.UserId;
                playerStat1.Result = p.Result;
                playerStat1.PlayDate = p.PlayDate;
                playerStat1.Username = p.Username;
                vm.Add(playerStat1);
            }
            return vm;
        }
    }
}