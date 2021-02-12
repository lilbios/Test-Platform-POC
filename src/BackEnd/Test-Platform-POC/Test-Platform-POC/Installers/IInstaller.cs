using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Test_Platform_POC.Installers
{
    public interface IInstaller
    {
        public void AddService(IServiceCollection service, IConfiguration configuration = null);
    }
}
