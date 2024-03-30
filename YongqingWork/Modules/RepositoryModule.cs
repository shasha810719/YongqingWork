using Autofac;
using YongqingWork.Repositories;

namespace YongqingWork.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TestRepository>().As<ITestRepository>().InstancePerLifetimeScope();
        }
    }
}
