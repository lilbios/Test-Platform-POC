using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Test_Platform_POC.Data;

namespace Test_Platform_POC.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void AddService(IServiceCollection service, IConfiguration configuration = null)
        {
            service.AddSingleton<AppDbContext>();
        }
    }
}
