using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Quartz;

namespace CronJobDemo
{
    public class HostedServices : BackgroundService
    {
        private IScheduler _scheduler;

        public HostedServices(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            IJobDetail jobDetail = JobBuilder.Create<MyJob>().WithIdentity("myJob", "group1").Build();

            ITrigger trigger = TriggerBuilder.Create().WithIdentity("myTrigger", "group1").StartNow()
                .WithCronSchedule("0/15 * * * * ?").Build();

            await _scheduler.ScheduleJob(jobDetail, trigger);

            await _scheduler.Start();


            Console.WriteLine("Scheduler started. Waiting for jobs to run...");

            await Task.Delay(TimeSpan.FromMinutes(1));

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            await _scheduler.Shutdown();
        }
    }
}
