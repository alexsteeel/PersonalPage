using Autofac;
using PersonalPage.Core;
using PersonalPage.Data.Repositories;

namespace PersonalPage.Data
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationUserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
        }
    }
}
