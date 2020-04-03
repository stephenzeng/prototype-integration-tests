using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyProjects.Prototypes.IntegrationTests.Api;
using MyProjects.Prototypes.IntegrationTests.Api.Controllers;
using MyProjects.Prototypes.IntegrationTests.Dal;
using MyProjects.Prototypes.IntegrationTests.Domain;

namespace MyProjects.Prototypes.IntegrationTests.Tests
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.AddControllers().AddApplicationPart(typeof(StoresController).Assembly);
        }

        protected override void ConfigureDbContext(IServiceCollection services)
        {
            var inMemoryConnectionString = "DataSource=:memory:";
            var connection = new SqliteConnection(inMemoryConnectionString);
            connection.Open();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(connection)
                .Options;

            var dbContext = new ApplicationDbContext(options);
            dbContext.Database.EnsureCreated();
            Seed(dbContext);

            services.AddSingleton(s => dbContext);
        }

        private static void Seed(ApplicationDbContext dbContext)
        {
            dbContext.Stores.Add(new Store { Name = "Test A Store" });
            dbContext.Stores.Add(new Store { Name = "Test B Store" });
            dbContext.SaveChanges();
        }
    }
}