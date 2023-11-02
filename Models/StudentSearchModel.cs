using System.ComponentModel.DataAnnotations;
using Nop.Plugin.Widgets.HelloWorldWidget.Domain;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;


namespace Nop.Plugin.Widgets.HelloWorldWidget.Models;
public record StudentSearchModel : BaseSearchModel
{

    [NopResourceDisplayName("Plugins.Widgets.HelloWorldWidget.Fields.Name")]
    public string SearchName { get; set; }

    [DataType(DataType.Date)]
    [UIHint("DateTimeNullable")]
    [NopResourceDisplayName("Plugins.Widgets.HelloWorldWidget.Fields.SearchDOBFrom")]
    public DateTime? SearchDOBFrom { get; set; }

    [DataType(DataType.Date)]
    [UIHint("DateTimeNullable")]
    [NopResourceDisplayName("Plugins.Widgets.HelloWorldWidget.Fields.SearchDOBTo")]
    public DateTime? SearchDOBTo { get; set; }

    [NopResourceDisplayName("Plugins.Widgets.HelloWorldWidget.Fields.MaritalStatus")]
    public IList<MaritalStatus> SelectedMaritalStatus { get; set; }

}
