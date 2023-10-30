namespace LN7.PL.Test
{
    [TestClass]
    public class WeightClassTest : BaseTest
    {
        [TestMethod]
        public void LoadTest()
        {
            var weightclasss = ln.tblWeightClasses;
            Assert.IsTrue(weightclasss.Count() > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblWeightClass newRow = new tblWeightClass();

            newRow.Id = 99;
            newRow.Description = "Test";

            ln.tblWeightClasses.Add(newRow);
            int rowsAffected = ln.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            tblWeightClass row = ln.tblWeightClasses.FirstOrDefault();

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
            tblWeightClass row = (from r in ln.tblWeightClasses select r).FirstOrDefault();

            if (row != null)
            {
                ln.tblWeightClasses.Remove(row);
                int rowsAffected = ln.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}