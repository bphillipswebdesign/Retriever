namespace LN7.API.Test
{
    [TestClass]
    public class UserControllerTest : BaseTest
    {
        [TestMethod]
        public async Task LoadTestAsync()
        {
            await base.LoadTestAsync<User>();
        }

        [TestMethod]
        public async Task InsertTestAsync()
        {
            User user = new User { First_Name = "Test" };
            await base.InsertTestAsync<User>(user);

        }

        [TestMethod]
        public async Task DeleteTestAsync()
        {
            await base.DeleteTestAsync<User>(new KeyValuePair<string, string>("First_Name", "Boonlert"));
        }

        [TestMethod]
        public async Task LoadByIdTestAsync()
        {
            await base.LoadByIdTestAsync<User>(new KeyValuePair<string, string>("First_Name", "Boonlert"));
        }

        [TestMethod]
        public async Task UpdateTestAsync()
        {
            var key = "First_Name";
            var value = "Boonlert";
            User user = null;
            try
            {
                var filter = new KeyValuePair<string, string>(key, value);
                user = await base.LoadByIdAsync<User>(filter);

                if (user != null)
                {
                    user.First_Name = "Test";
                    user.Last_Name = "Test";
                    await base.UpdateTestAsync<User>(new KeyValuePair<string, string>("Password", "test"), user);
                }
                else
                {
                    Assert.IsNotNull(user, $"{key} of {value} not found.");
                }
            }
            catch (Exception)
            {
                Debug.WriteLine($"{key} of {value} not found.");
                Assert.IsNotNull(user, $"{key} of {value} not found.");
            }

        }

    }
}