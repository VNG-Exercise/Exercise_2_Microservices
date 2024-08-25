using CartService.Helpers;

namespace CartService
{
    public class ConfigCollection
    {
        private readonly IConfigurationRoot configuration;

        public static ConfigCollection Instance { get; } = new ConfigCollection();

        protected ConfigCollection()
        {
            var env = AppUtils.GetEnv();

            configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env}.json", optional: true)
               .AddEnvironmentVariables()
               .Build();
        }

        public IConfigurationRoot GetConfiguration()
        {
            return configuration;
        }
    }

    public class AppSettings
    {
    }
}
