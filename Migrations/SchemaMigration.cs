using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.Widgets.HelloWorldWidget.Domain;

namespace Nop.Plugin.Pickup.PickupInStore.Data
{
    [NopMigration("2023/10/31 09:30:17:6455422", "Widget.HelloWorldWidget base schema", MigrationProcessType.Installation)]
    public class SchemaMigration : AutoReversingMigration
    {
        public override void Up()
        {
            Create.TableFor<Student>();
        }
    }
}