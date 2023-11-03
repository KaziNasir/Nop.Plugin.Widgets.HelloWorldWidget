using Nop.Core;

namespace Nop.Plugin.Widgets.HelloWorldWidget.Domain;
public class Student : BaseEntity
{
    public string Name { get; set; }
    public DateTime? DOB { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
}
