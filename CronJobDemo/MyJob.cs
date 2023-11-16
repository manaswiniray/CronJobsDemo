using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CronJobDemo
{
    public class MyJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Job Executing at: ",DateTime.Now);
            return Task.CompletedTask;
        }
    }
}
