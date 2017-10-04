using System;
using System.Diagnostics;
using Quartz;
using Quartz.Impl;

namespace car_sharing_system.Models {
	public class DBScheduler {

		// schedule a database check every x minute
		public static void scheduleDatabaseCheck(int min) {
			IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
			scheduler.Start();

			IJobDetail job = JobBuilder.Create<DatabaseCheckupJob>().Build();

			// TODO, set withintervalinminutes.
			// withintervalinseconds is used for debugging.
			ITrigger trigger = TriggerBuilder.Create()
			.WithDailyTimeIntervalSchedule
			(s => s.WithIntervalInMinutes(min)).Build();

			scheduler.ScheduleJob(job, trigger);
		}

		// Testing method. used to set a scheduled job to run at a date.
		public static void schedule2() {
			IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
			scheduler.Start();
			DateTime starttime = DateTime.Now.AddMinutes(1);
			Debug.WriteLine("start at " + starttime.ToString("yyyy-MM-dd HH:mm:ss"));
			IJobDetail job = JobBuilder.Create<DatabaseCheckupJob>().Build();
			ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder.Create()
				.WithIdentity("trigger1", "group1")
				.StartAt(starttime) // some Date 
				.Build();
			scheduler.ScheduleJob(job, trigger);
		}
	}

	public class DatabaseCheckupJob : IJob {
		public void Execute(IJobExecutionContext context) {
			DatabaseReader.changeCarStatusInterval();
		}
	}
}