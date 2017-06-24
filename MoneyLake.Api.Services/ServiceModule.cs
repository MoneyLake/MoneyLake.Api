using Autofac;
using MoneyLake.Api.DataAccess;
using MoneyLake.Api.Services.Impl;

namespace MoneyLake.Api.Services
{
    public class ServiceModule: Module
    {
        public string ConnectionString { get; set; }
        public ServiceModule(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override void Load(ContainerBuilder moduleBuilder)
        {
            moduleBuilder
                .Register(x => new PlantService(
                    x.Resolve<DataContext>()))
                .As<IPlantService>()
                .InstancePerLifetimeScope();

            moduleBuilder
                .Register(x => new DataContext(ConnectionString))
                .As<DataContext>()
                .SingleInstance();
        }
    }
}
