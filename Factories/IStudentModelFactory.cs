using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Widgets.HelloWorldWidget.Models;

namespace Nop.Plugin.Widgets.HelloWorldWidget.Factories;
public interface IStudentModelFactory
{
    Task<StudentListModel> PrepareStudentListModelAsync(StudentSearchModel searchModel);

    Task<StudentSearchModel> PrepareStudentSearchModelAsync(StudentSearchModel searchModel);
}
