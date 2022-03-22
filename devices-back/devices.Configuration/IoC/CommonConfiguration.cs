using Microsoft.Extensions.Configuration;
using System;

namespace devices.Configuration.IoC
{
    public class CommonConfiguration : ICommonConfiguration
    {
        public virtual IConfiguration Configuration { get; private set; }

        public CommonConfiguration(IConfiguration config)
        {
            Configuration = config;
        }

        private string GetValue(string configName)
        {
            return Configuration[configName] ?? throw new ArgumentNullException($"Missing configuration value '{configName}'");
        }

        public string DBHostName => GetValue("DBHostName");
        public string DBName => GetValue("DBName");
        public string DBUserName => GetValue("DBUserName");
        public string DBPassword => GetValue("DBPassword");
        public string DBPort => GetValue("DBPort");
    }
}
