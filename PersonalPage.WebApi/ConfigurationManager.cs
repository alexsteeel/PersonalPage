using Microsoft.Extensions.Configuration;
using System.IO;

namespace PersonalPage.WebApi
{
    public class ConfigurationManager : IConfigurationManager
    {
        public IConfiguration AppSetting { get; }
        public ConfigurationManager()
        {
            AppSetting = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
        }

        public string GetConnectionString()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            return connectionString;
        }
    }
}
