namespace LN7.PL.Test
{
    [TestClass]
    public class OriginTest : BaseTest
    {
        [TestMethod]
        public void LoadTest()
        {
            var origins = ln.tblOrigins;
            Assert.IsTrue(origins.Count() > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblOrigin newRow = new tblOrigin();

            newRow.Id = 99;
            newRow.Description = "Test";

            ln.tblOrigins.Add(newRow);
            int rowsAffected = ln.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            tblOrigin row = ln.tblOrigins.FirstOrDefault();

            if (row != null)
            {
                row.Description = "Test";

                int rowsAffected = ln.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();
            tblOrigin row = (from r in ln.tblOrigins select r).FirstOrDefault();

            if (row != null)
            {
                ln.tblOrigins.Remove(row);
                int rowsAffected = ln.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}