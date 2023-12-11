using Microsoft.Extensions.Configuration;

namespace ConfigurationService
{
    public static class ConfigSettings
    {
        static ConfigSettings()
        {
            string basePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Dictionary<string, string> appSettings;
            Dictionary<string, string> jobSettings = new Dictionary<string, string>();

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(basePath) // Set the base path here
                .AddJsonFile("appsettings.json");

            IConfigurationRoot configuration = builder.Build();
            appSettings = configuration.GetSection("AppSettings")
                .GetChildren()
                .ToDictionary(item => item.Key, item => item.Value);

            try
            {
                IConfigurationBuilder jobSettingsBuilder = new ConfigurationBuilder()
                    .SetBasePath(basePath) // Set the base path here as well
                    .AddJsonFile("jobsettings.json");

                IConfigurationRoot jobConfiguration = jobSettingsBuilder.Build();
                jobSettings = jobConfiguration.GetSection("AppSettings")
                    .GetChildren()
                    .ToDictionary(item => item.Key, item => item.Value);
            }
            catch (FileNotFoundException) { }

            AppSettings = jobSettings.Concat(appSettings)
                .GroupBy(d => d.Key)
                .ToDictionary(d => d.Key, d => d.First().Value);
        }

        public static Dictionary<string, string> AppSettings { get; private set; }

        public static string GetInlineConnectionString()
        {
            string server = AppSettings["dbserver"];
            string username = AppSettings["username"];
            string pwd = AppSettings["password"];
            string dbname = AppSettings["dbname"];
            bool IsGsmaEnabled = Convert.ToBoolean(AppSettings["IsGSMAEnabled"]);
            string connString = string.Format("Server={0};Database={1};User ID={2};Password={3};Encrypt={4}", server, dbname, username, pwd, false);
            if (IsGsmaEnabled)
            {
                connString = string.Format("Server={0};Database={1};Trusted_Connection=True;Encrypt={2}", server, dbname, false);
            }

            string maxPoolSize = AppSettings["MaxPoolSize"];
            if (!string.IsNullOrWhiteSpace(maxPoolSize))
            {
                connString += ";Max Pool Size = " + maxPoolSize;
            }
            return connString;
        }

        public static string GetSPConnectionString()
        {
            string server = AppSettings["dbserver"];
            string username = AppSettings["username"];
            string pwd = AppSettings["password"];
            string dbname = AppSettings["dbname"];
            bool IsGsmaEnabled = Convert.ToBoolean(AppSettings["IsGSMAEnabled"]);
            string connString = string.Format("Server={0};Database={1};User ID={2};Password={3};Encrypt={4}", server, dbname, username, pwd, false);
            if (IsGsmaEnabled)
            {
                connString = string.Format("Server={0};Database={1};Trusted_Connection=True;Encrypt={2}", server, dbname, false);
            }

            string maxPoolSize = AppSettings["MaxPoolSize"];
            if (!string.IsNullOrWhiteSpace(maxPoolSize))
            {
                connString += ";Max Pool Size = " + maxPoolSize;
            }
            return connString;
        }
    }
}
