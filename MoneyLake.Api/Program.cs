
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace MoneyLake.Api
{
    internal class Program
    {
        private static void Main()
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
