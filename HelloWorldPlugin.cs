using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Nop.Plugin.Widgets.HelloWorldWidget.Components;
using Nop.Services.Cms;
using Nop.Services.Plugins;
using Nop.Web.Framework;
using Nop.Web.Framework.Infrastructure;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Widgets.HelloWorldWidget;
public class HelloWorldPlugin : BasePlugin, IWidgetPlugin, IAdminMenuPlugin
{
    public bool HideInWidgetList => false;

    public Type GetWidgetViewComponent(string widgetZone)
    {
        return typeof(WidgetsHelloWorldViewComponent);
    }

    public async Task<IList<string>> GetWidgetZonesAsync()
    {
        return await Task.FromResult<IList<string>>(new List<string> { PublicWidgetZones.HomepageTop });
    }

    public override async Task InstallAsync()
    {
        await base.InstallAsync();
    }

    public Task ManageSiteMapAsync(SiteMapNode rootNode)
    {
        var menuItem = new SiteMapNode()
        {
            SystemName = "Hello World Plugin",
            Title = "Students",
            ControllerName = "HelloWorld",
            ActionName = "Configure",
            IconClass = "far fa-dot-circle",
            Visible = true,
            RouteValues = new RouteValueDictionary() { { "area", AreaNames.Admin } },
        };
        var pluginNode = rootNode.ChildNodes.FirstOrDefault(x => x.SystemName == "Third party plugins");
        if (pluginNode != null)
            pluginNode.ChildNodes.Add(menuItem);
        else
            rootNode.ChildNodes.Add(menuItem);

        return Task.CompletedTask;
    }

    public override async Task UninstallAsync()
    {
        await base.UninstallAsync();
    }



}
