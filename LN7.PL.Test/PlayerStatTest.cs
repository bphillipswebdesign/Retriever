namespace LN7.PL.Test
{
    [TestClass]
    public class PlayerStatTest : BaseTest
    {
        [TestMethod]
        public void LoadTest()
        {
            var playerstats = ln.tblPlayerStats;
            Assert.IsTrue(playerstats != null);
        }

        [TestMethod]
        public void InsertTest()
        {
            Guid newG = Guid.NewGuid();
            tblPlayerStat playerstat = new tblPlayerStat();
            playerstat.UserId = newG;
            playerstat.PlayDate = DateTime.Now;
            playerstat.Result = true;

            ln.tblPlayerStats.Add(playerstat);
            int rowsAffected = ln.SaveChanges();
            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblPlayerStat row = (from r in ln.tblPlayerStats select r).FirstOrDefault();

            if (row != null)
            {
                ln.tblPlayerStats.Remove(row);
                int rowsAffected = ln.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}