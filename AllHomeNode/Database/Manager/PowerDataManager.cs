using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AllHomeNode.Database.Model;
using NHibernate;
using static AllHomeNode.Service.MQTT.Enums;

namespace AllHomeNode.Database.Manager
{
    class PowerDataManager
    {
        public void Add(PowerData item)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                session.Save(item);
                session.Flush();
            }
        }

        public IList<PowerData> GetOldestPowerConsume(string deviceId, DateTime startTime, DateTime endTime, POWERCONSUMERTYPE type)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<PowerData> data = session.QueryOver<PowerData>().Where
                    (c => (c.GatewayId == deviceId && c.TimeStamp >= startTime && c.TimeStamp <= endTime && c.PowerType == type.ToString()))
                    .OrderBy(c => c.TimeStamp)
                    .Asc
                    .List();
                return data;
            }
        }

        public IList<PowerData> GetPowerConsume(string deviceId, DateTime startTime, DateTime endTime, POWERCONSUMERTYPE type)
        {
            string powerConsumeType = type.ToString();
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<PowerData> data = session.QueryOver<PowerData>().Where
                    (c => (c.GatewayId == deviceId && c.PowerType.Equals(powerConsumeType) && c.TimeStamp >= startTime && c.TimeStamp <= endTime))
                    .OrderBy(c => c.TimeStamp)
                    .Desc
                    .List();
                return data;
            }
        }

        public IList<PowerData> GetPowerConsume(string deviceId, DateTime startTime, DateTime endTime)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<PowerData> data = session.QueryOver<PowerData>().Where
                    (c => (c.GatewayId == deviceId && c.TimeStamp >= startTime && c.TimeStamp <= endTime))
                    .OrderBy(c => c.TimeStamp)
                    .Desc
                    .List();
                return data;
            }
        }
    }
}
