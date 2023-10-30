using Microsoft.EntityFrameworkCore.Storage;

namespace LN7.PL.Test
{
    [TestClass]
    public class CoatLengthTest : BaseTest
    {
        [TestMethod]
        public void LoadTest()
        {
            var coatlengths = ln.tblCoatLengths;
            Assert.IsTrue(coatlengths.Count() > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblCoatLength newRow = new tblCoatLength();

            newRow.Id = 99;
            newRow.Description = "Test";

            ln.tblCoatLengths.Add(newRow);
            int rowsAffected = ln.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            tblCoatLength row = ln.tblCoatLengths.FirstOrDefault();

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
            tblCoatLength row = (from r in ln.tblCoatLengths select r).FirstOrDefault();

            if (row != null)
            {
                ln.tblCoatLengths.Remove(row);
                int rowsAffected = ln.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
