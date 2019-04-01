using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkerTest
{
    /// <summary>
    /// Create a Windows Service with dotNet Core.  
    /// From Glen Condron's article here: https://devblogs.microsoft.com/aspnet/net-core-workers-as-windows-services/
    /// 
    /// </summary>


    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(loggerFactory => loggerFactory.AddEventLog())
                .UseServiceBaseLifetime()
                .ConfigureServices(services =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
