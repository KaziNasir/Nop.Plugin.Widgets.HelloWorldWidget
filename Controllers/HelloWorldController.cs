using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.HelloWorldWidget.Domain;
using Nop.Plugin.Widgets.HelloWorldWidget.Factories;
using Nop.Plugin.Widgets.HelloWorldWidget.Models;
using Nop.Plugin.Widgets.HelloWorldWidget.Services;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc;
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

    [HttpPost]
    public async Task<IActionResult> Create(StudentModel model)
    {
        var student = new Student()
        {
            Name = model.Name,
            DOB = DateOnly.FromDateTime((DateTime) model.DOB),
            MaritalStatus = model.MaritalStatus
        };
        _studentService.InsertStudentAsync(student);

        ViewBag.RefreshPage = true;

        return View("~/Plugins/Widgets.HelloWorldWidget/Views/Create.cshtml", model);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var student = await _studentService.GetStorePickupPointByIdAsync(id);

        if (student == null)
            return RedirectToAction("Configure");

        var model = new StudentModel()
        {
            Id = student.Id,
            Name = student.Name,
            DOB = student.DOB.ToDateTime(TimeOnly.MinValue),
            MaritalStatus = student.MaritalStatus
        };
        return View("~/Plugins/Widgets.HelloWorldWidget/Views/Edit.cshtml", model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(StudentModel model)
    {
        var student = new Student()
        {
            Id = model.Id,
            Name = model.Name,
            DOB = DateOnly.FromDateTime((DateTime)model.DOB),
            MaritalStatus = model.MaritalStatus
        };
        _studentService.UpdateStudentAsync(student);

        ViewBag.RefreshPage = true;

        return View("~/Plugins/Widgets.HelloWorldWidget/Views/Edit.cshtml", model);
    }

    public async Task<IActionResult> Delete(int id) 
    {
        var student = await _studentService.GetStorePickupPointByIdAsync(id);
        
        await _studentService.DeleteStudentAsync(student);

        return new NullJsonResult();
    }
}