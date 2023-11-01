using Nop.Core;
using Nop.Plugin.Widgets.HelloWorldWidget.Domain;

namespace Nop.Plugin.Widgets.HelloWorldWidget.Services;
public interface IStudentService
{
    Task<IPagedList<Student>> GetAllStudentsAsync(int studentId = 0, int pageIndex = 0, int pageSize = int.MaxValue);
}
