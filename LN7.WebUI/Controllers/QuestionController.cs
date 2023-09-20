using LN7.BL.Models;
using LN7.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        public async Task <IActionResult> DisplayQuestion()
        {
            try
            {
                int questionState = 1;
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

        public async Task<IActionResult> AnswerQuestion(bool answer, int questionState)
{
    try
    {
        // Increment the questionState
        questionState++;

        // Load the next question based on the updated questionState
        GameQuestion question = await GameManager.LoadById(questionState);

        if (question != null)
        {
            return View("Index", question); // Display the next question
        }
        else
        {
            return View("FinalResult"); // Handle the end of questions
        }
    }
    catch (Exception ex)
    {
        // Handle exceptions here
        return View("Error");
    }
}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
