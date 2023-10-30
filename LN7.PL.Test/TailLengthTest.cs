namespace LN7.PL.Test
{
    [TestClass]
    public class TailLengthTest : BaseTest
    {
        [TestMethod]
        public void LoadTest()
        {
            var taillengths = ln.tblTailLengths;
            Assert.IsTrue(taillengths.Count() > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblTailLength newRow = new tblTailLength();

            newRow.Id = 99;
            newRow.Description = "Test";

            ln.tblTailLengths.Add(newRow);
            int rowsAffected = ln.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            tblTailLength row = ln.tblTailLengths.FirstOrDefault();

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
            tblTailLength row = (from r in ln.tblTailLengths select r).FirstOrDefault();

            if (row != null)
            {
                ln.tblTailLengths.Remove(row);
                int rowsAffected = ln.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}