using Microsoft.EntityFrameworkCore.Storage;

namespace LN7.PL.Test
{
    [TestClass]
    public class EarLengthTest : BaseTest
    {
        [TestMethod]
        public void LoadTest()
        {
            var bodytypes = ln.tblEarLengths;
            Assert.IsTrue(bodytypes.Count() > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblEarLength newRow = new tblEarLength();

            newRow.Id = 99;
            newRow.Description = "Test";

            ln.tblEarLengths.Add(newRow);
            int rowsAffected = ln.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            tblEarLength row = ln.tblEarLengths.FirstOrDefault();

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
            tblEarLength row = (from r in ln.tblEarLengths select r).FirstOrDefault();

            if (row != null)
            {
                ln.tblEarLengths.Remove(row);
                int rowsAffected = ln.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
