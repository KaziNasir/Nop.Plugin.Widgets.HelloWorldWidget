using Microsoft.AspNetCore.Routing;
using Nop.Plugin.Widgets.HelloWorldWidget.Components;
using Nop.Services.Cms;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework;
using Nop.Web.Framework.Infrastructure;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Widgets.HelloWorldWidget;
public class HelloWorldPlugin : BasePlugin, IWidgetPlugin, IAdminMenuPlugin
{
    public bool HideInWidgetList => false;

    protected readonly ILocalizationService _localizationService;

    public HelloWorldPlugin(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
    }

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
        await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
        {
            ["Plugins.Widgets.HelloWorldWidget.AddNew"] = "Add a new Student",
            ["Plugins.Widgets.HelloWorldWidget.Fields.Name"] = "Name",
            ["Plugins.Widgets.HelloWorldWidget.Fields.DOB"] = "Date of Birth",
            ["Plugins.Widgets.HelloWorldWidget.Fields.MaritalStatus"] = "Marital Status",
            ["Plugins.Widgets.HelloWorldWidget.Fields.SearchDOBFrom"] = "Date of Birth From",
            ["Plugins.Widgets.HelloWorldWidget.Fields.SearchDOBTo"] = "Date of Birth To"
        });
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
        await _localizationService.DeleteLocaleResourcesAsync("Plugins.Widgets.HelloWorldWidget");
        await base.UninstallAsync();
    }



}
