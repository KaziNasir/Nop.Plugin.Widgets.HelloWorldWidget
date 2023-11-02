using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Plugin.Widgets.HelloWorldWidget.Factories;
using Nop.Plugin.Widgets.HelloWorldWidget.Services;

namespace Nop.Plugin.Widgets.HelloWorldWidget.Infrastructure;
public class NopStartup : INopStartup
{
    public int Order => 3000;

    public void Configure(IApplicationBuilder application)
    {

    }

    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IStudentService, StudentService>()
            .AddScoped<IStudentModelFactory, StudentModelFactory>();
    }
}
