namespace LN7.PL.Test
{
    [TestClass]
    public class QuestionTest : BaseTest
    {
        [TestMethod]
        public void LoadTest()
        {
            var questions = ln.tblQuestions;
            Assert.IsTrue(questions.Count() > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblQuestion newRow = new tblQuestion();

            newRow.Id = 99;
            newRow.Question = "Test";
            newRow.Trait_Id = 1;
            newRow.Answer = 1;


            ln.tblQuestions.Add(newRow);
            int rowsAffected = ln.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            tblQuestion row = ln.tblQuestions.FirstOrDefault();

            if (row != null)
            {
                row.Question = "Test";
                row.Trait_Id = 2;
                row.Answer = 2;
                int rowsAffected = ln.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();
            tblQuestion row = (from r in ln.tblQuestions select r).FirstOrDefault();

            if (row != null)
            {
                ln.tblQuestions.Remove(row);
                int rowsAffected = ln.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}