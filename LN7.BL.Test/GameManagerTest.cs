using LN7.BL;
using LN7.BL.Models;
using LN7.PL;
using Microsoft.EntityFrameworkCore.Storage;

namespace LN7.BL.Test
{
    [TestClass]
    public class GameManagerTest
    {
        protected LN7Entities ln;
        protected IDbContextTransaction tx;

        [TestInitialize]
        public void TestInitialize()
        {
            ln = new LN7Entities();
            tx = ln.Database.BeginTransaction();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            tx.Rollback();
            tx.Dispose();
        }

        [TestMethod]
        public async Task LoadByIdTest()
        {
            int Id = 1;
            GameQuestion question = await GameManager.LoadById(Id);
            Assert.IsNotNull(question);
        }

        [TestMethod]
        public void LoadQuestionsTest()
        {
            List<GameQuestion> questions = GameManager.Load();
            Assert.AreEqual(47, questions.Count);
        }

        [TestMethod]
        public async Task LoadDogsTest()
        {
            List<Dog> dogs = await GameManager.LoadDog();
            Assert.AreEqual(24, dogs.Count);
        }

        [TestMethod]
        public async Task RemoveNoTest()
        {
            List<Dog> dogs = await GameManager.LoadDog();
            GameQuestion question = GameManager.Load().FirstOrDefault();
            bool answer = true;
            Assert.AreNotEqual(dogs.Count, GameManager.RemoveNo(question, dogs, answer).Count);
        }
    }
}