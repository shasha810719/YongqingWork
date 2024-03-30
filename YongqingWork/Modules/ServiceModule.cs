using Autofac;
using YongqingWork.Services;


namespace YongqingWork.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TestService>().As<ITestService>().InstancePerLifetimeScope();
        }
    }
}
