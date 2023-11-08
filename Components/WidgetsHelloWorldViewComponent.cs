using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.HelloWorldWidget.Components;
public class WidgetsHelloWorldViewComponent : NopViewComponent
{

    public async Task<IViewComponentResult> InvokeAsync(string widgetZone)
    {
        return await Task.FromResult(View("~/Plugins/Widgets.HelloWorldWidget/Views/HelloWorld.cshtml"));
    }
}
