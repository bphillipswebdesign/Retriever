using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using LN7.BL.Models;
using LN7.PL;
using System.Text;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Numerics;

namespace LN7.BL
{
    public static class GameManager
    {
        public async static Task<GameQuestion> LoadById(int id)
        {
            try
            {
                using (LN7Entities dc = new LN7Entities())
                {
                    tblQuestion tblQuestion = await dc.tblQuestions.Where(c => c.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);

                    if (tblQuestion != null)
                    {
                        GameQuestion question = new GameQuestion();
                        question.Id = tblQuestion.Id;
                        question.Question = tblQuestion.Question;
                        return question;
                    }
                    else
                    {
                        throw new Exception("Could not find the row");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<GameQuestion> Load()
        {
            try
            {
                List<GameQuestion> rows = new List<GameQuestion>();

                using (LN7Entities dc = new LN7Entities())
                {
                    dc.tblQuestions
                        .ToList()
                        .ForEach(s => rows.Add(new GameQuestion
                        {
                            Id = s.Id,
                            Question = s.Question,

                        }));
                    return rows;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}