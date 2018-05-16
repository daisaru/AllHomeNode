using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Quartz;
using AllHomeNode.Repository;

namespace AllHomeNode.Service.Quartz
{
    public class QuartzTask_SummaryPowerData : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }

        public static void SummaryDailyPower()
        {
            DataRepository dataRepo = new DataRepository();
            dataRepo.SummaryDailyPowerData();
        }

        public static void SummaryMonthlyPower()
        {
            DataRepository dataRepo = new DataRepository();
            dataRepo.SummaryMonthlyPowerData();
        }
    }
}
