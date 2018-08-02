using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

using Quartz;
using Quartz.Impl;

namespace AllHomeNode.Service.Quartz
{
    public class Service_Quartz
    {
        private static Service_Quartz _instance = null;

        private Timer _dailyTimer = null;

        private Service_Quartz()
        {

        }

        /// <summary>
        /// 初始化Timer控件
        /// </summary>
        public void StartTimer()
        {
            //设置定时间隔(毫秒为单位)
            int interval = 1000 * 60 * 60;     
            _dailyTimer = new System.Timers.Timer(interval);
            _dailyTimer.Elapsed += new System.Timers.ElapsedEventHandler(TimerUp);
            //设置执行一次（false）还是一直执行(true)
            _dailyTimer.AutoReset = true;                              // !!! ATTENTION: false for debug
            //设置是否执行System.Timers.Timer.Elapsed事件
            _dailyTimer.Enabled = true;
            //绑定Elapsed事件
        }

        public void StopTimer()
        {
            if(_dailyTimer != null)
            {
                _dailyTimer.Enabled = false;
            }
        }

        /// <summary>
        /// Timer类执行定时到点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerUp(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                DateTime dtNow = DateTime.Now;

                // For Debug
                //QuartzTask_SummaryPowerData.SummaryMonthlyPower();
                //QuartzTask_SummaryPowerData.SummaryDailyPower();

                if (dtNow.Hour == 0)
                {
                    if(dtNow.Day == 1)
                    {
                        // 每个月的第一天凌晨统计前一个月的电量
                        QuartzTask_SummaryPowerData.SummaryMonthlyPower();                        
                    }
                    else
                    {
                        // 每天凌晨统计前一天的电量
                        QuartzTask_SummaryPowerData.SummaryDailyPower();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static Service_Quartz Instance()
        {
            if (_instance == null)
                _instance = new Service_Quartz();

            return _instance;
        }

        #region Quartz.Net
        /// <summary>
        /// 时间间隔执行任务
        /// </summary>
        /// <typeparam name="T">任务类，必须实现IJob接口</typeparam>
        /// <param name="seconds">时间间隔(单位：毫秒)</param>
        public static void ExecuteInterval<T>(int seconds) where T : IJob
        {
            ISchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = (IScheduler)factory.GetScheduler();

            //IJobDetail job = JobBuilder.Create<T>().WithIdentity("job1", "group1").Build();
            IJobDetail job = JobBuilder.Create<T>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(seconds).RepeatForever())
                .Build();

            scheduler.ScheduleJob(job, trigger);

            scheduler.Start();
        }

        /// <summary>
        /// 指定时间执行任务
        /// </summary>
        /// <typeparam name="T">任务类，必须实现IJob接口</typeparam>
        /// <param name="cronExpression">cron表达式，即指定时间点的表达式</param>
        public static void ExecuteByCron<T>(string cronExpression) where T : IJob
        {
            ISchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = (IScheduler)factory.GetScheduler();

            IJobDetail job = JobBuilder.Create<T>().Build();

            //DateTimeOffset startTime = DateBuilder.NextGivenSecondDate(DateTime.Now.AddSeconds(1), 2);
            //DateTimeOffset endTime = DateBuilder.NextGivenSecondDate(DateTime.Now.AddYears(2), 3);

            ICronTrigger trigger = (ICronTrigger)TriggerBuilder.Create()
                //.StartAt(startTime).EndAt(endTime)
                .WithCronSchedule(cronExpression)
                .Build();

            scheduler.ScheduleJob(job, trigger);

            scheduler.Start();

            //Thread.Sleep(TimeSpan.FromDays(2));
            //scheduler.Shutdown();
        }
        #endregion
    }
}
