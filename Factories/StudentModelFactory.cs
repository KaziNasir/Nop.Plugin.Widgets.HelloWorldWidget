﻿using Nop.Plugin.Widgets.HelloWorldWidget.Models;
using Nop.Plugin.Widgets.HelloWorldWidget.Services;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Plugin.Widgets.HelloWorldWidget.Factories;
public class StudentModelFactory : IStudentModelFactory
{
    private readonly IStudentService _studentService;

    public StudentModelFactory(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public async Task<StudentListModel> PrepareStudentListModelAsync(StudentSearchModel searchModel)
    {
        var students = await _studentService.GetAllStudentsAsync(pageIndex: searchModel.Page - 1, pageSize: searchModel.PageSize,
            searchName: searchModel.SearchName, searchDOBFrom: searchModel.SearchDOBFrom, searchDOBTo: searchModel.SearchDOBTo, selectedMaritalStatus: searchModel.SelectedMaritalStatus);

        var model = await new StudentListModel().PrepareToGridAsync(searchModel, students, () =>
        {
            return students.SelectAwait(async student =>
            {
                return new StudentModel()
                {
                    Id = student.Id,
                    Name = student.Name,
                    DOB = student.DOB,
                    MaritalStatus = student.MaritalStatus
                };

            });
        });

        return model;
    }

    public Task<StudentSearchModel> PrepareStudentSearchModelAsync(StudentSearchModel searchModel)
    {
        if (searchModel == null)
            throw new ArgumentNullException(nameof(searchModel));

        //prepare page parameters
        searchModel.SetGridPageSize();

        return Task.FromResult(searchModel);
    }
}
