using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentNHibernate.Mapping;

namespace AllHomeNode.Database.Model
{
    class MapHeartbeat : ClassMap<Heartbeat>
    {
        public MapHeartbeat()
        {
            Id(x => x.Id).Column("Id");

            Map(x => x.GatewayId).Column("GatewayId");
            Map(x => x.SoftwareVersion).Column("SoftwareVersion");
            Map(x => x.HardwareVersion).Column("HardwareVersion");
            Map(x => x.DeviceTime).Column("GatewayTime");
            Map(x => x.TimeStamp).Column("TimeStamp");

            Table("tb_heartbeat");
        }
    }
}
