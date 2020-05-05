using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PersonalPage.Data;

namespace PersonalPage.WebApi
{
    /// <summary>
    /// Only for migrations.
    /// </summary>
    public class DBContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            var connectionString = new ConfigurationManager().GetConnectionString();
            optionsBuilder.UseSqlServer(connectionString,
                    x => x.MigrationsAssembly("PersonalPage.Data"));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
