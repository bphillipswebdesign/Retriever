namespace LN7.PL.Test
{
    [TestClass]
    public class LegLengthTest : BaseTest
    {
        [TestMethod]
        public void LoadTest()
        {
            var leglengths = ln.tblLegLengths;
            Assert.IsTrue(leglengths.Count() > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblLegLength newRow = new tblLegLength();

            newRow.Id = 99;
            newRow.Description = "Test";

            ln.tblLegLengths.Add(newRow);
            int rowsAffected = ln.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            tblLegLength row = ln.tblLegLengths.FirstOrDefault();

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
            tblLegLength row = (from r in ln.tblLegLengths select r).FirstOrDefault();

            if (row != null)
            {
                ln.tblLegLengths.Remove(row);
                int rowsAffected = ln.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
