﻿using Quartz;
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
            
            Console.WriteLine("My Job Executing At: "+ DateTime.Now);
            return Task.CompletedTask;
        }
    }
}
