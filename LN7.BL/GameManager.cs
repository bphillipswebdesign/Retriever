using LN7.BL.Models;
using LN7.PL;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LN7.BL
{
    public static class GameManager
    {
        public static async Task<GameQuestion> LoadById(int id)
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
                        question.Answer = tblQuestion.Answer;
                        question.Trait_Id = tblQuestion.Trait_Id;

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
                            Trait_Id = s.Trait_Id,
                            Answer = s.Answer
                        }));
                    return rows;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Task<List<Dog>> LoadDog()
        {
            try
            {
                List<Dog> rows = new List<Dog>();

                using (LN7Entities dc = new LN7Entities())
                {
                    dc.tblDogs
                        .ToList()
                        .ForEach(s => rows.Add(new Dog
                        {
                            Id = s.Id,
                            BreedName = s.BreedName,
                            Imagepath = s.Imagepath,
                            DogGroup = s.DogGroup,
                            CoatColor = s.CoatColor,
                            CoatType = s.CoatType,
                            CoatLength = s.CoatLength,
                            EarType = s.EarType,
                            EarLength = s.EarLength,
                            LegLength = s.LegLength,
                            BodyType = s.BodyType,
                            MuzzleType = s.MuzzleType,
                            MuzzleLength = s.MuzzleLength,
                            TailType = s.TailType,
                            TailLength = s.TailLength,
                            WeightClass = s.WeightClass
                        }));
                    return Task.FromResult(rows);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Dog> RemoveNo(GameQuestion question, List<Dog> dogs, bool answer)
        {
            try
            {
                string prop = ((QuestionTraits.TraitsMap)question.Trait_Id).ToString();
                switch (answer)
                {
                    case false:
                        foreach (Dog d in dogs.ToList())
                        {
                            PropertyInfo? pName = typeof(Dog).GetProperty(prop);
                            object? value = pName.GetValue(d, null);
                            if ((int)value == question.Answer)
                            {
                                dogs.Remove(d);
                            }
                        }
                        break;

                    case true:
                        foreach (Dog d in dogs.ToList())
                        {
                            PropertyInfo? pName = typeof(Dog).GetProperty(prop);
                            object? value = pName.GetValue(d, null);
                            if ((int)value != question.Answer)
                            {
                                dogs.Remove(d);
                            }
                        }
                        break;
                }
            }
            catch
            {
                // Error in try
            }
            return dogs;
        }

            public static async Task<List<int>> ListFilter(int questionState, List<int> shuffledQuestions, bool answer)
            {
                GameQuestion question = await LoadById(questionState);

                List<int> questionsToRemove = new List<int>();

                if (answer)
                {
                    // Loop through each remaining Question
                    foreach (int i in shuffledQuestions)
                    {
                        GameQuestion q = await LoadById(i);

                        if (question.Trait_Id == q.Trait_Id)
                        {
                            questionsToRemove.Add(i);
                        }
                    }
                }
                else
                {
                    shuffledQuestions.Remove(questionState);
                }

                foreach (int questionToRemove in questionsToRemove)
                {
                    shuffledQuestions.Remove(questionToRemove);
                }

                return shuffledQuestions;
            }
    }
}