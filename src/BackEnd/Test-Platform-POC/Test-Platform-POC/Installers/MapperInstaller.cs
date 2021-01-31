using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Test_Platform_POC.Installers
{
    public class MapperInstaller : IInstaller
    {
        public void AddService(IServiceCollection service, IConfiguration configuration = null)
        {
            service.AddAutoMapper(typeof(Startup));
        }
    }
}
