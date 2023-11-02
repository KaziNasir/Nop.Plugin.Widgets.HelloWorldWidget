using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Tools;
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

    public virtual async Task<IPagedList<Student>> GetAllStudentsAsync(int studentId = 0, int pageIndex = 0, int pageSize = int.MaxValue, 
        string? searchName = null, DateTime? searchDOBFrom = null, DateTime? searchDOBTo = null, IList<MaritalStatus> selectedMaritalStatus = null)
    {
        var rez = await _studentRepository.GetAllAsync(query =>
        {
            if (studentId > 0)
                query = query.Where(student => student.Id == studentId || student.Id == 0);

            if(searchName != null && searchName != "")
            {
                query = query.Where(s => s.Name.Contains(searchName));
            }

            if (searchDOBFrom.HasValue)
            {
                if (searchDOBTo.HasValue)
                {
                    query = query.Where(s => s.DOB >= DateOnly.FromDateTime((DateTime)searchDOBFrom)
                    && s.DOB <= DateOnly.FromDateTime((DateTime)searchDOBTo));
                }
                else
                {
                    query = query.Where(s => s.DOB == DateOnly.FromDateTime((DateTime)searchDOBFrom));
                }                
            }

            if (selectedMaritalStatus != null && selectedMaritalStatus.Any())
            {
                query = query.Where(s => s.MaritalStatus.In(selectedMaritalStatus));
            }

            query = query.OrderBy(student => student.Name);

            return query;
        });

        return new PagedList<Student>(rez, pageIndex, pageSize);
    }
    public virtual async Task<Student> GetStorePickupPointByIdAsync(int studentId)
    {
        return await _studentRepository.GetByIdAsync(studentId);
    }
    public virtual async Task InsertStudentAsync(Student student)
    {
        await _studentRepository.InsertAsync(student, false);
    }

    public virtual async Task UpdateStudentAsync(Student student)
    {
        await _studentRepository.UpdateAsync(student, false);
    }
    public virtual async Task DeleteStudentAsync(Student student)
    {
        await _studentRepository.DeleteAsync(student, false);
    }
}
