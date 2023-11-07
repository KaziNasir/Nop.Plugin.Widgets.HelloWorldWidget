using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.HelloWorldWidget.Domain;
using Nop.Plugin.Widgets.HelloWorldWidget.Factories;
using Nop.Plugin.Widgets.HelloWorldWidget.Models;
using Nop.Plugin.Widgets.HelloWorldWidget.Services;
using Nop.Services.Localization;
using Nop.Services.Messages;
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
    private readonly INotificationService _notificationService;
    private readonly ILocalizationService _localizationService;

    public HelloWorldController(IStudentService studentService, IStudentModelFactory studentModelFactory, INotificationService notificationService, ILocalizationService localizationService)
    {
        _studentService = studentService;
        _studentModelFactory = studentModelFactory;
        _notificationService = notificationService;
        _localizationService = localizationService;
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

    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
    public async Task<IActionResult> Create(StudentModel model, bool continueEditing)
    {
        if (!model.DOB.HasValue || model.DOB.Value > DateTime.Today)
        {
            ModelState.AddModelError("DOB", "Invalid Date of Birth.");
            return View("~/Plugins/Widgets.HelloWorldWidget/Views/Create.cshtml", model);
        }

        var student = new Student()
        {
            Name = model.Name,
            DOB = model.DOB,
            MaritalStatus = model.MaritalStatus
        };
        await _studentService.InsertStudentAsync(student);

        ViewBag.RefreshPage = true;

        if (!continueEditing)
            return RedirectToAction("Configure");

        return RedirectToAction("Edit", new { id = student.Id });
    }

    public async Task<IActionResult> Edit(int id)
    {
        var student = await _studentService.GetStorePickupPointByIdAsync(id);

        if (student == null)
            return RedirectToAction("Configure");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Student dob: " + student.DOB.ToString());
        Console.ForegroundColor = ConsoleColor.White;

        var model = new StudentModel()
        {
            Id = student.Id,
            Name = student.Name,
            DOB = student.DOB,
            MaritalStatus = student.MaritalStatus
        };

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("StudentModel dob: " + model.DOB.ToString());
        Console.ForegroundColor = ConsoleColor.White;

        return View("~/Plugins/Widgets.HelloWorldWidget/Views/Edit.cshtml", model);
    }

    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
    public async Task<IActionResult> Edit(StudentModel model, bool continueEditing)
    {
        var student = new Student()
        {
            Id = model.Id,
            Name = model.Name,
            DOB = model.DOB,
            MaritalStatus = model.MaritalStatus
        };
        await _studentService.UpdateStudentAsync(student);

        ViewBag.RefreshPage = true;

        if (!continueEditing)
            return RedirectToAction("Configure");

        return RedirectToAction("Edit", new { id = student.Id });
    }

    public async Task<IActionResult> Delete(int id)
    {
        var student = await _studentService.GetStorePickupPointByIdAsync(id);

        await _studentService.DeleteStudentAsync(student);

        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Plugin.Widgets.HelloWorldWidget.Deleted"));

        return RedirectToAction("Configure");
    }
}