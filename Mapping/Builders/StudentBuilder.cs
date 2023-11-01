using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator.Builders.Create.Table;
using Nop.Data.Extensions;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Widgets.HelloWorldWidget.Domain;

namespace Nop.Plugin.Widgets.HelloWorldWidget.Mapping.Builders;
public class StudentBuilder : NopEntityBuilder<Student>
{
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table.WithColumn(nameof(Student.Id)).AsInt32().PrimaryKey().Identity()
            .WithColumn(nameof(Student.Name)).AsString(50)
            .WithColumn(nameof(Student.DOB)).AsDate()
            .WithColumn(nameof(Student.MaritalStatus)).AsInt16();
    }
}
