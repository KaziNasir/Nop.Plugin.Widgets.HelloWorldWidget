using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Data;
using Nop.Plugin.Widgets.HelloWorldWidget.Domain;

namespace Nop.Plugin.Widgets.HelloWorldWidget.Services;
public class StudentService : IStudentService
{
    private readonly IRepository<Student> _studentRepository;
    public StudentService(IRepository<Student> studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public virtual async Task<IPagedList<Student>> GetAllStudentsAsync(int studentId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
    {
        var rez = await _studentRepository.GetAllAsync(query =>
        {
            if (studentId > 0)
                query = query.Where(student => student.Id == studentId || student.Id == 0);
            query = query.OrderBy(student => student.Name);

            return query;
        });

        return new PagedList<Student>(rez, pageIndex, pageSize);
    }

    public virtual async Task InsertStudentAsync(Student student)
    {
        await _studentRepository.InsertAsync(student, false);
    }

    public virtual async Task UpdateStudentAsync(Student student)
    {
        await _studentRepository.UpdateAsync(student, false);
    }
}
