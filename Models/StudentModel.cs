using System.ComponentModel.DataAnnotations;
using Nop.Plugin.Widgets.HelloWorldWidget.Domain;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.HelloWorldWidget.Models;
public record StudentModel : BaseNopEntityModel
{
    [NopResourceDisplayName("Plugins.Widgets.HelloWorldWidget.Fields.Name")]
    public string Name { get; set; }

    [UIHint("DateNullable")]
    [NopResourceDisplayName("Plugins.Widgets.HelloWorldWidget.Fields.DOB")]
    public DateTime? DOB { get; set; }

    [NopResourceDisplayName("Plugins.Widgets.HelloWorldWidget.Fields.MaritalStatus")]
    public MaritalStatus MaritalStatus { get; set; }

    [NopResourceDisplayName("Plugins.Widgets.HelloWorldWidget.Fields.MaritalStatus")]
    public string GetMaritalStatus
    {
        get => Enum.GetName(typeof(MaritalStatus), MaritalStatus);
    }
}
