using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model
{
    class MapGatewayDeviceBind : ClassMap<GatewayDeviceBind>
    {
        public MapGatewayDeviceBind()
        {
            Id(x => x.Id).Column("Id");

            Map(x => x.Id_Gateway).Column("Id_Gateway");
            Map(x => x.Id_Device).Column("Id_Device");
            Map(x => x.TimeStamp).Column("TimeStamp");

            Table("tb_gatewaydevicebind");
        }
    }
}
