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

        public void SummaryDailyPower(DateTime date)
        {
            DataRepository dataRepo = new DataRepository();
        }
    }
}
