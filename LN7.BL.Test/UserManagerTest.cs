using LN7.BL.Models;
using LN7.PL;

namespace LN7.BL.Test
{
    [TestClass]
    public class UserManagerTest : BaseTest
    {
        [TestMethod]
        public async Task LoginTest()
        {
            User user = new User { First_Name = "Boon", Last_Name = "Xiong", Username = "bxiong", Password = "pass", Email = "", Is_Admin = true };
            bool result = UserManager.Login(user);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public async Task LoginFailTest()
        {
            try
            {
                User user = new User { First_Name = "Boon", Last_Name = "Xiong", Username = "bxiong", Password = "1234", Email = "", Is_Admin = true };
                bool result = UserManager.Login(user);
                Assert.Fail();
            }
            catch (LoginFailureEx)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public async Task LoadTest()
        {
            IEnumerable<User> users = await UserManager.Load();
            Assert.IsNotNull(users);
        }
        [TestMethod]
        public async Task LoadByIdTest()
        {
            IEnumerable<User> users = await UserManager.Load();
            Assert.IsNotNull(users);
        }
        [TestMethod]
        public async Task InsertTest()
        {
            User user = new User { First_Name = "New", Last_Name = "User", Username = "nuser", Password = "1234", Email = "", Is_Admin = false };
            int result = await UserManager.Insert(user);
            Assert.IsTrue(result > 0);
        }
        [TestMethod]
        public async Task UpdateTest()
        {
            LN7Entities ln = new LN7Entities();
            tblUser row = ln.tblUsers.FirstOrDefault();
            if (row != null)
            {
                row.First_Name = "NewFirst";
                row.Last_Name = "NewLast";
                int results = ln.SaveChanges();
                Assert.AreEqual(1, results);
            }
        }
        [TestMethod]
        public async Task DeleteTests()
        {
            LN7Entities ln = new LN7Entities();
            tblUser row = ln.tblUsers.FirstOrDefault();
            if (row != null)
            {
                int result = await UserManager.Delete(row.Id);
                Assert.IsTrue(result == 1);
            }
        }
    }
}