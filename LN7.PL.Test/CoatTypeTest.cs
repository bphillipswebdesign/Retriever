using Microsoft.EntityFrameworkCore.Storage;

namespace LN7.PL.Test
{
    [TestClass]
    public class CoatTypeTest : BaseTest
    {
        [TestMethod]
        public void LoadTest()
        {
            var coattypes = ln.tblCoatTypes;
            Assert.IsTrue(coattypes.Count() > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblCoatType newRow = new tblCoatType();

            newRow.Id = 99;
            newRow.Description = "Test";

            ln.tblCoatTypes.Add(newRow);
            int rowsAffected = ln.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            tblCoatType row = ln.tblCoatTypes.FirstOrDefault();

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
            tblCoatType row = (from r in ln.tblCoatTypes select r).FirstOrDefault();

            if (row != null)
            {
                ln.tblCoatTypes.Remove(row);
                int rowsAffected = ln.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
