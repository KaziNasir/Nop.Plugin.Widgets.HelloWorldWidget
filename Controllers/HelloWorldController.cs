using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.HelloWorldWidget.Factories;
using Nop.Plugin.Widgets.HelloWorldWidget.Models;
using Nop.Plugin.Widgets.HelloWorldWidget.Services;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.HelloWorldWidget.Controllers;

[AutoValidateAntiforgeryToken]
[AuthorizeAdmin]
[Area(AreaNames.Admin)]
public class HelloWorldController : BasePluginController
{
    private readonly IStudentService _studentService;
    private readonly IStudentModelFactory _studentModelFactory;

    public HelloWorldController(IStudentService studentService, IStudentModelFactory studentModelFactory)
    {
        _studentService = studentService;
        _studentModelFactory = studentModelFactory;
    }

    public virtual async Task<IActionResult> Configure()
    {
        var model = await _studentModelFactory.PrepareStudentSearchModelAsync(new StudentSearchModel());
        return View("~/Plugins/Widgets.HelloWorldWidget/Views/Configure.cshtml", model);
    }

    [HttpPost]
    public async Task<IActionResult> List(StudentSearchModel searchModel)
    {
        //prepare model
        var model = await _studentModelFactory.PrepareStudentListModelAsync(searchModel);

        return Json(model);
    }

    public async Task<IActionResult> Create()
    {
        var model = new StudentModel();
        return View("~/Plugins/Widgets.HelloWorldWidget/Views/Create.cshtml", model);

    }
}