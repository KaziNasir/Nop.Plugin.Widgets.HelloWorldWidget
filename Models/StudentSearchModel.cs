using Nop.Plugin.Widgets.HelloWorldWidget.Domain;
using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.HelloWorldWidget.Models;
public record StudentSearchModel : BaseSearchModel
{
    /*public StudentSearchModel()
    {
        SearchName = "";
        SearchDOB = null;
        SearchMaritalStatus = null;
    }*/

    [NopResourceDisplayName("Plugins.Widgets.HelloWorldWidget.Fields.Name")]
    public string SearchName { get; set; }

    [DataType(DataType.Date)]
    [UIHint("DateTimeNullable")]
    [NopResourceDisplayName("Plugins.Widgets.HelloWorldWidget.Fields.DOB")]
    public DateTime? SearchDOB { get; set; }

    [NopResourceDisplayName("Plugins.Widgets.HelloWorldWidget.Fields.MaritalStatus")]
    public MaritalStatus? SearchMaritalStatus { get; set; }
}
