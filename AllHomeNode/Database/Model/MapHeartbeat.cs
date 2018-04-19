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

            Map(x => x.DeviceId).Column("DeviceId");
            Map(x => x.SoftwareVersion).Column("SoftwareVersion");
            Map(x => x.HardwareVersion).Column("HardwareVersion");
            Map(x => x.DeviceTime).Column("DeviceTime");
            Map(x => x.TimeStamp).Column("TimeStamp");

            Table("tb_heartbeat");
        }
    }
}
