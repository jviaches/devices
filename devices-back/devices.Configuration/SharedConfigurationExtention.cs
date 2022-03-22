using devices.Configuration.IoC;
using Microsoft.Extensions.Configuration;
using System;

namespace devices.Configuration
{
    public static class SharedConfigurationExtention
    {
        public static CommonConfiguration SharedConfig(this IConfiguration configuration)
        {
            return new CommonConfiguration(configuration);
        }
    }
}
