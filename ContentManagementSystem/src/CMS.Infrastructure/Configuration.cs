using Microsoft.Extensions.Configuration;

namespace CMS.Infrastructure;

public static class Configuration
{
    public static string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../CMS.API"));
            configurationManager.AddJsonFile("appsettings.json");

            return configurationManager.GetConnectionString("MSSQl");
        }
    }
}
