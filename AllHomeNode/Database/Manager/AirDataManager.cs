using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AllHomeNode.Database.Model;
using NHibernate;

namespace AllHomeNode.Database.Manager
{
    class AirDataManager
    {
        public void Add(AirData item)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(item);
                session.Flush();
            }
        }

        public IList<AirData> GetHistoryAirQuality(string deviceId, DateTime startTime, DateTime endTime)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<AirData> data = session.QueryOver<AirData>().Where
                    (c => (c.DeviceId == deviceId && c.TimeStamp >= startTime && c.TimeStamp <= endTime)).List();
                return data;
            }
        }
    }
}
