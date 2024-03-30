using Autofac;
using YongqingWork.Modules.Setting;

namespace YongqingWork.Modules
{
    public class DatebaseModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            builder.RegisterType<DatabaseConnection>()
        .As<IDatabaseConnection>()
        .WithParameter("connectionString", @"Server=DESKTOP-TS1CSVQ\SQLEXPRESS;Database=master;Integrated Security=True;")
        .SingleInstance();
        }
    }

}
