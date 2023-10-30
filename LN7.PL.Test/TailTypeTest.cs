namespace LN7.PL.Test
{
    [TestClass]
    public class TailTypeTest : BaseTest
    {
        [TestMethod]
        public void LoadTest()
        {
            var tailtypes = ln.tblTailTypes;
            Assert.IsTrue(tailtypes.Count() > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblTailType newRow = new tblTailType();

            newRow.Id = 99;
            newRow.Description = "Test";

            ln.tblTailTypes.Add(newRow);
            int rowsAffected = ln.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            tblTailType row = ln.tblTailTypes.FirstOrDefault();

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
            tblTailType row = (from r in ln.tblTailTypes select r).FirstOrDefault();

            if (row != null)
            {
                ln.tblTailTypes.Remove(row);
                int rowsAffected = ln.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}