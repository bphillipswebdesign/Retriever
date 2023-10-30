namespace LN7.PL.Test
{
    [TestClass]
    public class MuzzleLengthTest : BaseTest
    {
        [TestMethod]
        public void LoadTest()
        {
            var muzzlelengths = ln.tblMuzzleLengths;
            Assert.IsTrue(muzzlelengths.Count() > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblMuzzleLength newRow = new tblMuzzleLength();

            newRow.Id = 99;
            newRow.Description = "Test";

            ln.tblMuzzleLengths.Add(newRow);
            int rowsAffected = ln.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            tblMuzzleLength row = ln.tblMuzzleLengths.FirstOrDefault();

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
            tblMuzzleLength row = (from r in ln.tblMuzzleLengths select r).FirstOrDefault();

            if (row != null)
            {
                ln.tblMuzzleLengths.Remove(row);
                int rowsAffected = ln.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}