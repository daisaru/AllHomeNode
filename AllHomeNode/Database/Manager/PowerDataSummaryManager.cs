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
                    (c => (c.DeviceId == deviceId && c.SummaryTime >= startTime && c.SummaryTime <= endTime && c.IsMonth == 1))
                    .OrderBy(c => c.SummaryTime)
                    .Desc
                    .List();
                return data;
            }
        }

        public PowerDataSummary GetOldestMonthPowerSummary(string deviceId, DateTime startTime, DateTime endTime)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                List<PowerDataSummary> datas = session.QueryOver<PowerDataSummary>().Where
                    (c => (c.DeviceId == deviceId && c.SummaryTime >= startTime && c.SummaryTime <= endTime && c.IsMonth == 1))
                    .OrderBy(c => c.SummaryTime)
                    .Asc
                    .List()
                    .ToList();
                if (datas != null && datas.Count > 0)
                    return datas[0];
                else
                    return null;
            }
        }

        public PowerDataSummary GetLatestMonthPowerSummary(string deviceId, DateTime startTime, DateTime endTime)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                List<PowerDataSummary> datas = session.QueryOver<PowerDataSummary>().Where
                    (c => (c.DeviceId == deviceId && c.SummaryTime <= endTime && c.IsMonth == 1)) //&& c.SummaryTime >= startTime
                    .OrderBy(c => c.SummaryTime)
                    .Desc
                    .List()
                    .ToList();
                if (datas != null && datas.Count > 0)
                    return datas[0];
                else
                    return null;
            }
        }

        public PowerDataSummary GetLatestPowerSummary(string deviceId, DateTime startTime, DateTime endTime)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                List<PowerDataSummary> datas = session.QueryOver<PowerDataSummary>().Where
                    (c => (c.DeviceId == deviceId && c.SummaryTime >= startTime && c.SummaryTime <= endTime && c.IsMonth == 0))
                    .OrderBy(c => c.SummaryTime)
                    .Desc
                    .List()
                    .ToList();
                if (datas != null && datas.Count > 0)
                    return datas[0];
                else
                    return null;
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
