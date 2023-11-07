using System.Text.Json;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.HelloWorldWidget.Factories;
using Nop.Plugin.Widgets.HelloWorldWidget.Models;
using Nop.Plugin.Widgets.HelloWorldWidget.Services;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.HelloWorldWidget.Controllers;

[AutoValidateAntiforgeryToken]
public class PublicStudentPageController : BasePluginController
{
    private readonly IStudentService _studentService;
    private readonly IStudentModelFactory _studentModelFactory;

    public PublicStudentPageController(IStudentService studentService, IStudentModelFactory studentModelFactory)
    {
        _studentService = studentService;
        _studentModelFactory = studentModelFactory;
    }

    public async Task<IActionResult> Index()
    {
        var model = await _studentModelFactory.PrepareStudentSearchModelAsync(new StudentSearchModel());
        return View("~/Plugins/Widgets.HelloWorldWidget/Views/PublicPage.cshtml", model);
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {

        var searchModel = await _studentModelFactory.PrepareStudentSearchModelAsync(new StudentSearchModel());
        //prepare model
        var model = await _studentModelFactory.PrepareStudentListModelAsync(searchModel);

        return Json(JsonSerializer.Serialize(model));
    }
}
