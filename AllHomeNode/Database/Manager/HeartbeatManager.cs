using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AllHomeNode.Database.Model;

namespace AllHomeNode.Database.Manager
{
    class HeartbeatManager
    {
        public IList<Heartbeat> GetHeartbeats(string gatewayId, DateTime startTime, DateTime endTime)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<Heartbeat> data = session.QueryOver<Heartbeat>()
                    .Where(c => (c.GatewayId == gatewayId && c.TimeStamp >= startTime && c.TimeStamp <= endTime))
                    .OrderBy(c => c.TimeStamp)
                    .Desc
                    .List();
                return data;
            }
        }
    }
}
