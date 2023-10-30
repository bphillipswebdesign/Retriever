using Microsoft.EntityFrameworkCore.Storage;

namespace LN7.PL.Test
{
    [TestClass]
    public class DogGroupTest : BaseTest
    {
        [TestMethod]
        public void LoadTest()
        {
            var doggroups = ln.tblDogGroups;
            Assert.IsTrue(doggroups.Count() > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblDogGroup newRow = new tblDogGroup();

            newRow.Id = 99;
            newRow.Description = "Test";

            ln.tblDogGroups.Add(newRow);
            int rowsAffected = ln.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            tblDogGroup row = ln.tblDogGroups.FirstOrDefault();

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
            tblDogGroup row = (from r in ln.tblDogGroups select r).FirstOrDefault();

            if (row != null)
            {
                ln.tblDogGroups.Remove(row);
                int rowsAffected = ln.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
