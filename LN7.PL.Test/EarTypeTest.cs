namespace LN7.PL.Test
{
    [TestClass]
    public class EarTypeTest : BaseTest
    {
        [TestMethod]
        public void LoadTest()
        {
            var eartypes = ln.tblEarTypes;
            Assert.IsTrue(eartypes.Count() > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblEarType newRow = new tblEarType();

            newRow.Id = 99;
            newRow.Description = "Test";

            ln.tblEarTypes.Add(newRow);
            int rowsAffected = ln.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            tblEarType row = ln.tblEarTypes.FirstOrDefault();

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
            tblEarType row = (from r in ln.tblEarTypes select r).FirstOrDefault();

            if (row != null)
            {
                ln.tblEarTypes.Remove(row);
                int rowsAffected = ln.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
