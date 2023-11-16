using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace CronJobDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureServices((hostCOntext, services) =>
                {
                    services.AddSingleton<IScheduler>(provider =>
                    {
                        ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
                        return schedulerFactory.GetScheduler().Result;
                    });
                    services.AddHostedService<HostedServices>();
                }).Build();

            await host.RunAsync();
        }
    }
}