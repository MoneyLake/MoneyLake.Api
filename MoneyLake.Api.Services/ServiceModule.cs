using Autofac;
using MoneyLake.Api.DataAccess;
using MoneyLake.Api.Services.Impl;

namespace MoneyLake.Api.Services
{
    public class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder moduleBuilder)
        {
            moduleBuilder
                .Register(x => new PlantService(
                    x.Resolve<DataContext>()))
                .As<IPlantService>()
                .InstancePerLifetimeScope();
            
            moduleBuilder
                .Register(x => new UserService(
                    x.Resolve<DataContext>()))
                .As<IUserService>()
                .InstancePerLifetimeScope();


            moduleBuilder
                .RegisterType<DataContext>()
                .As<DataContext>()
                .InstancePerLifetimeScope();
        }
    }
}
