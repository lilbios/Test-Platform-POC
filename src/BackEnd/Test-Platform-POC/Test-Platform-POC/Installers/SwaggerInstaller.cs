using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Test_Platform_POC.Installers
{
    public  class SwaggerInstaller : IInstaller
    {
        public  void AddService(IServiceCollection service, IConfiguration configuration)
        {
            service.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Test Platform POC",
                    Version = "v1",
                    Description = "Web-based API for testing platform",
                    Contact = new OpenApiContact
                    {
                        Name = "Yehor Shamrai"
                    }

                });
            });
        }
    }
}
