using Microsoft.EntityFrameworkCore;
using MyProjects.Prototypes.IntegrationTests.Domain;

namespace MyProjects.Prototypes.IntegrationTests.Dal
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Store> Stores { get; set; }
    }
}
