using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model
{
    class MapUserGatewayBind : ClassMap<UserGatewayBind>
    {
        public MapUserGatewayBind()
        {
            Id(x => x.Id).Column("Id");

            Map(x => x.Id_User).Column("Id_User");
            Map(x => x.Id_Gateway).Column("Id_Gateway");
            Map(x => x.GatewayGivenName).Column("GatewayGivenName");
            Map(x => x.Privilege).Column("Privilege");
            Map(x => x.Time).Column("Time");
            Map(x => x.TimeStamp).Column("TimeStamp");

            Table("tb_usergatewaybind");
        }
    }
}
