using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework.Mvc.Routing;

namespace Nop.Plugin.Widgets.HelloWorldWidget.Infrastructure;
public class RouteProvider : IRouteProvider
{
    public int Priority => 0;

    public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapControllerRoute(name: "Plugin.Widgets.HelloWorldWidget",
                pattern: "Student/All",
                defaults: new { controller = "PublicStudentPage", action = "Index" });

        endpointRouteBuilder.MapControllerRoute(name: "Plugin.Widgets.HelloWorldWidget",
                pattern: "Student/List",
                defaults: new { controller = "PublicStudentPage", action = "List" });
    }
}
