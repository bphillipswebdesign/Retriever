namespace LN7.PL.Test
{
    [TestClass]
    public class UserTest : BaseTest
    {
        [TestMethod]
        public void LoadTest()
        {
            var users = ln.tblUsers;
            Assert.IsTrue(users.Count() > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblUser newRow = new tblUser();

            newRow.Id = Guid.NewGuid();
            newRow.First_Name = "FirstName";
            newRow.Last_Name = "LastName";
            newRow.Username = "XXXXXX";
            newRow.Password = "YYYYY";
            newRow.Date_Created = DateTime.Now;
            newRow.Email = "newemail@email.com";
            newRow.Is_Admin = true;

            ln.tblUsers.Add(newRow);
            int rowsAffected = ln.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            tblUser row = ln.tblUsers.FirstOrDefault();

            if (row != null)
            {
                row.First_Name = "FirstName";
                row.Last_Name = "LastName";
                row.Username = "XXXXXX";
                row.Password = "YYYYY";
                row.Date_Created = DateTime.Now;
                row.Email = "newemail@email.com";
                row.Is_Admin = false;
                int rowsAffected = ln.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();
            tblUser row = (from r in ln.tblUsers select r).FirstOrDefault();

            if (row != null)
            {
                ln.tblUsers.Remove(row);
                int rowsAffected = ln.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}