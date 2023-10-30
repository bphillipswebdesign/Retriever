namespace LN7.PL.Test
{
    [TestClass]
    public class MuzzleTypeTest : BaseTest
    {
        [TestMethod]
        public void LoadTest()
        {
            var muzzletypes = ln.tblMuzzleTypes;
            Assert.IsTrue(muzzletypes.Count() > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblMuzzleType newRow = new tblMuzzleType();

            newRow.Id = 99;
            newRow.Description = "Test";

            ln.tblMuzzleTypes.Add(newRow);
            int rowsAffected = ln.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            tblMuzzleType row = ln.tblMuzzleTypes.FirstOrDefault();

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
            tblMuzzleType row = (from r in ln.tblMuzzleTypes select r).FirstOrDefault();

            if (row != null)
            {
                ln.tblMuzzleTypes.Remove(row);
                int rowsAffected = ln.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}