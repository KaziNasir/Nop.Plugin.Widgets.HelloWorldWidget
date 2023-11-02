using Nop.Core;
using Nop.Plugin.Widgets.HelloWorldWidget.Domain;

namespace Nop.Plugin.Widgets.HelloWorldWidget.Services;
public interface IStudentService
{
    Task<IPagedList<Student>> GetAllStudentsAsync(int studentId = 0, int pageIndex = 0, int pageSize = int.MaxValue,
        string? searchName = null, DateTime? searchDOBFrom = null, DateTime? searchDOBTo = null, IList<MaritalStatus>? selectedMaritalStatus = null);
    Task InsertStudentAsync(Student student);
    Task UpdateStudentAsync(Student student);
    Task DeleteStudentAsync(Student student);
    Task<Student> GetStorePickupPointByIdAsync(int studentId);
}
