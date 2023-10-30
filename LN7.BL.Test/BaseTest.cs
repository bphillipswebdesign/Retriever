using LN7.PL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

namespace LN7.BL.Test
{
    [TestClass]
    public abstract class BaseTest
    {
        protected LN7Entities ln;
        protected IDbContextTransaction tx;
        private IConfigurationRoot _configuration;

        // Represent the database configuration
        protected DbContextOptions<LN7Entities> options;

        public BaseTest()
        {
            // Install nuget packages Microsoft.Extensions.Configuration and M.E.C.Json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();

            options = new DbContextOptionsBuilder<LN7Entities>()
                .UseSqlServer(_configuration.GetConnectionString("LN7Connection"))
                .Options;

            ln = new LN7Entities(options);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            tx = ln.Database.BeginTransaction();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            tx.Rollback();
            tx.Dispose();
            ln = null;
        }
    }
}
