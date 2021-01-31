using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Test_Platform_POC.Installers
{
    public class AppDbContexInstaller : IInstaller
    {
        public void AddService(IServiceCollection service, IConfiguration configuration)
        {
            throw new NotImplementedException();
        }
    }
}
