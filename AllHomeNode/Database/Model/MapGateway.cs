using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model
{
    class MapGateway : ClassMap<Gateway>
    {
        public MapGateway()
        {
            Id(x => x.Id).Column("Id");

            Map(x => x.GatewayId).Column("GatewayId");
            Map(x => x.GatewayName).Column("GatewayName");
            Map(x => x.TimeStamp).Column("TimeStamp");

            Table("tb_gateway");
        }
    }
}
