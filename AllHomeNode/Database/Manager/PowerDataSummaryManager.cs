using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AllHomeNode.Database.Model;
using NHibernate;

namespace AllHomeNode.Database.Manager
{
    class PowerDataSummaryManager
    {
        public void Add(PowerDataSummary item)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(item);
                session.Flush();
            }
        }

        public IList<PowerDataSummary>GetMonthPowerConsumeSummary(string deviceId, DateTime startTime, DateTime endTime)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<PowerDataSummary> data = session.QueryOver<PowerDataSummary>().Where
                    (c => (c.DeviceId == deviceId && c.SummaryTime >= startTime && c.SummaryTime <= endTime && c.IsMonth == 1)).List();
                return data;
            }
        }

        public IList<PowerDataSummary> GetDayPowerConsumeSummary(string deviceId, DateTime startTime, DateTime endTime)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<PowerDataSummary> data = session.QueryOver<PowerDataSummary>().Where
                    (c => (c.DeviceId == deviceId && c.SummaryTime >= startTime && c.SummaryTime <= endTime)).List();
                return data;
            }
        }
    }
}
