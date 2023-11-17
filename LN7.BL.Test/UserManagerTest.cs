using LN7.BL.Models;
using LN7.PL;
using Microsoft.EntityFrameworkCore.Storage;

namespace LN7.BL.Test
{
    [TestClass]
    public class UserManagerTest
    {
        protected LN7Entities ln;
        protected IDbContextTransaction tx;

        [TestInitialize]
        public void TestInitialize()
        {
            ln = new LN7Entities();
            tx = ln.Database.BeginTransaction();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            tx.Rollback();
            tx.Dispose();
        }

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
                Assert.IsFalse(result);
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
            int result = await UserManager.Insert(user, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public async Task UpdateTest()
        {
            tblUser row = ln.tblUsers.FirstOrDefault();
            User user = await UserManager.LoadById(row.Id);
            user.First_Name = "New First";
            user.Last_Name = "New Last";
            user.Email = "New Email";
            user.Is_Admin = false;
            user.Password = "New Pass";
            user.Username = "New Username";

            Assert.IsTrue(await UserManager.Update(user, true) > 0);

        }

        [TestMethod]
        public async Task DeleteTests()
        {
            LN7Entities ln = new LN7Entities();
            tblUser row = ln.tblUsers.FirstOrDefault();
            if (row != null)
            {
                int result = await UserManager.Delete(row.Id, true);
                Assert.IsTrue(result == 1);
            }
        }
    }
}