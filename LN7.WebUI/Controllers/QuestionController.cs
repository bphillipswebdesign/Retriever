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

        // Showing User Question Method
        public async Task<IActionResult> DisplayQuestion(bool? answer)
        {
            try
            {
                int minQuestion = 1;
                int maxQuestion = 47;

                List<int> shuffledQuestions = HttpContext.Session.Get<List<int>>("shuffledQuestions");
                List<Dog> dogs = HttpContext.Session.Get<List<Dog>>("dogs");
                
                if (dogs == null)
                {
                    dogs = await GameManager.LoadDog();
                    HttpContext.Session.Set("dogs", dogs);
                }

                if (shuffledQuestions == null)
                {
                    shuffledQuestions = Enumerable.Range(minQuestion, maxQuestion).ToList();
                    ShuffleList(shuffledQuestions);

                    HttpContext.Session.Set("shuffledQuestions", shuffledQuestions);
                }

                int qId = shuffledQuestions.FirstOrDefault();

                if (qId == 0)
                {
                    HttpContext.Session.Remove("dogs");
                    HttpContext.Session.Remove("shuffledQuestions");
                    return View("AllQuestionsAsked");
                }                                                     

                if (answer.HasValue)
                {
                    //QuestionTraits questionTraits = new QuestionTraits();

                    dogs = GameManager.RemoveNo(await GameManager.LoadById(qId), dogs, answer.Value);
                    if (dogs.Count > 1)
                    {
                        HttpContext.Session.Set("dogs", dogs);
                    }
                    else if (dogs.Count == 1)
                    {
                        HttpContext.Session.Remove("dogs");
                        return View("~/Views/Question/DisplayGuess.cshtml", dogs[0].BreedName);
                    }
                    else
                    {
                        HttpContext.Session.Remove("dogs");
                        return View("~/Views/Question/AllQuestionsAsked.cshtml");
                    }

                    // Remove current question and any question with same Trait Id if Yes.
                    shuffledQuestions = await GameManager.ListFilter(qId, shuffledQuestions, answer.Value);

                    HttpContext.Session.Set("shuffledQuestions", shuffledQuestions);
                }

                GameQuestion question = await GameManager.LoadById(qId);

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

        // Method to shuffle a list
        private static void ShuffleList<T>(List<T> list)
        {
            Random random = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        // Resetting Question to 0
        [HttpPost]
        public IActionResult ResetSessionState()
        {
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
