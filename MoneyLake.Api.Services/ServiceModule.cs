using Autofac;
using MoneyLake.Api.Services.Impl;

namespace MoneyLake.Api.Services
{
    public class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder moduleBuilder)
        {
            moduleBuilder
                .RegisterType<PlantService>()
                .As<IPlantService>()
                .InstancePerLifetimeScope();
        }
    }
}
