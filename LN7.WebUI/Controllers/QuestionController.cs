using LN7.BL.Models;
using LN7.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using LN7.BL;
using LN7.PL;

namespace LN7.WebUI.Controllers
{
    
    public class QuestionController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public QuestionController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public async Task <IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> DisplayQuestion(bool? answer)
        {
            try
            {
                int questionState = HttpContext.Session.GetInt32("questionState") ?? 1;

                if (questionState < 0)
                {
                    return NotFound();
                }

                if (answer.HasValue && !answer.Value)
                {
                    questionState++;
                }

                HttpContext.Session.SetInt32("questionState", questionState);

                GameQuestion question = await GameManager.LoadById(questionState);

                if (question != null)
                {
                    return View(question);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult ResetSessionState()
        {
            HttpContext.Session.SetInt32("questionState", 0);
            return Ok();
        }

        public async Task<IActionResult> AnswerQuestion()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
