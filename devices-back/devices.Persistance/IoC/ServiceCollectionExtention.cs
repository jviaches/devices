using devices.Configuration;
using devices.Configuration.IoC;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace devices.Persistance
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICommonConfiguration, CommonConfiguration>();
            services.AddScoped<IDatabaseService, DatabaseService>();

            var DBHostName = configuration.SharedConfig().DBHostName;
            var DBName = configuration.SharedConfig().DBName;
            var DBUserName = configuration.SharedConfig().DBUserName;
            var DBPassword = configuration.SharedConfig().DBPassword;
            var DBPort = configuration.SharedConfig().DBPort;

            services.AddDbContext<DatabaseService>(options =>
            {
                if (string.IsNullOrEmpty(DBHostName) || string.IsNullOrEmpty(DBName) ||
                    string.IsNullOrEmpty(DBUserName) || string.IsNullOrEmpty(DBPassword) || string.IsNullOrEmpty(DBPort))
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
                else
                    options.UseNpgsql($"Host={DBHostName};Port={DBPort};Username={DBUserName};Password={DBPassword};Database={DBName};"); // used Postgress DB
            });
            return services;
        }
    }
}
