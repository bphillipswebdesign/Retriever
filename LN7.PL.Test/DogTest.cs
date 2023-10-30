namespace LN7.PL.Test
{
    [TestClass]
    public class DogTest : BaseTest
    {
        [TestMethod]
        public void LoadTest()
        {
            var dogs = ln.tblDogs;
            Assert.IsTrue(dogs.Count() > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblDog newRow = new tblDog();

            newRow.Id = 99;
            newRow.BreedName = "Test";
            newRow.Imagepath = "Test";
            newRow.DogGroup = 1;
            newRow.CoatColor = 1;
            newRow.CoatType = 1;
            newRow.CoatLength = 1;
            newRow.EarType = 1;
            newRow.EarLength = 1;
            newRow.LegLength = 1;
            newRow.BodyType = 1;
            newRow.MuzzleType = 1;
            newRow.MuzzleLength = 1;
            newRow.Origin = 1;
            newRow.TailType = 1;
            newRow.TailLength = 1;
            newRow.WeightClass = 1;

            ln.tblDogs.Add(newRow);
            int rowsAffected = ln.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            tblDog row = ln.tblDogs.FirstOrDefault();

            if (row != null)
            {
                row.BreedName = "Test";
                row.Imagepath = "Test";
                row.DogGroup = 2;
                row.CoatColor = 2;
                row.CoatType = 2;
                row.CoatLength = 2;
                row.EarType = 2;
                row.EarLength = 2;
                row.LegLength = 2;
                row.BodyType = 2;
                row.MuzzleType = 2;
                row.MuzzleLength = 2;
                row.Origin = 2;
                row.TailType = 2;
                row.TailLength = 2;
                row.WeightClass = 2;
                int rowsAffected = ln.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();
            tblDog row = (from r in ln.tblDogs select r).FirstOrDefault();

            if (row != null)
            {
                ln.tblDogs.Remove(row);
                int rowsAffected = ln.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
