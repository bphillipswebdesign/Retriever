using Microsoft.VisualStudio.TestTools.UnitTesting;
using LN7.BL.Models;
using LN7.BL;

namespace GameManagerTest
{
    [TestClass]
    public class GameManagerTests
    {
        [TestMethod]
        public async Task LoadByIdTest()
        {
            int Id = 1;
            GameQuestion question = await GameManager.LoadById(Id);
            Assert.IsNotNull(question);
        }

        [TestMethod]
        public async Task LoadByIdTestNull()
        {
            int Id = -1;
            GameQuestion question = await GameManager.LoadById(Id);
            Assert.IsNull(question);
        }
    }
}