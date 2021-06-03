using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntelligenceBattle.Services.GameManager.Context;
using IntelligenceBattle.Services.GameManager.Services;

namespace IntelligenceBattle.Services.GameManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient(x => new PublicContext("Host=185.87.48.116;Port=5434;Database=intelligencebattle;Username=postgres;Password=123123AAA"));
                    services.AddTransient<GameManagerService>();
                    services.AddHostedService<Worker>();
                });
    }
}
