using Nop.Plugin.Widgets.HelloWorldWidget.Models;

namespace Nop.Plugin.Widgets.HelloWorldWidget.Factories;
public interface IStudentModelFactory
{
    Task<StudentListModel> PrepareStudentListModelAsync(StudentSearchModel searchModel);

    Task<StudentSearchModel> PrepareStudentSearchModelAsync(StudentSearchModel searchModel);
}
