﻿using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Plugin.Widgets.HelloWorldWidget.Domain;

namespace Nop.Plugin.Widgets.HelloWorldWidget.Models;
public record StudentModel : BaseNopEntityModel
{
    [NopResourceDisplayName("Plugins.Widgets.HelloWorldWidget.Fields.Name")]
    public string Name { get; set; }

    [DataType(DataType.Date)]
    [NopResourceDisplayName("Plugins.Widgets.HelloWorldWidget.Fields.DOB")]
    public DateTime DOB { get; set; }

    [NopResourceDisplayName("Plugins.Widgets.HelloWorldWidget.Fields.MaritalStatus")]
    public MaritalStatus MaritalStatus { get; set; }
}