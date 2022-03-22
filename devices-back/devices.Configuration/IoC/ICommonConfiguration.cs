using Microsoft.Extensions.Configuration;

namespace devices.Configuration.IoC
{
    public interface ICommonConfiguration
    {
        IConfiguration Configuration { get; }
    }
}
