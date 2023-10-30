namespace LN7.PL.Test
{
    [TestClass]
    public class BodyTypeTest : BaseTest
    {
        [TestMethod]
        public void LoadTest()
        {
            var bodytypes = ln.tblBodyTypes;
            Assert.IsTrue(bodytypes.Count() > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblBodyType newRow = new tblBodyType();

            newRow.Id = 99;
            newRow.Description = "Test";

            ln.tblBodyTypes.Add(newRow);
            int rowsAffected = ln.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            tblBodyType row = ln.tblBodyTypes.FirstOrDefault();

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
            tblBodyType row = (from r in ln.tblBodyTypes select r).FirstOrDefault();

            if (row != null)
            {
                ln.tblBodyTypes.Remove(row);
                int rowsAffected = ln.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
