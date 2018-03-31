using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model
{
    class MapUserDeviceBind : ClassMap<UserDeviceBind>
    {
        public MapUserDeviceBind()
        {
            Id(x => x.Id).Column("Id");

            Map(x => x.Id_User).Column("Id_User");
            Map(x => x.Id_Device).Column("Id_Device");
            Map(x => x.DeviceGivenName).Column("DeviceGivenName");
            Map(x => x.Privilege).Column("Privilege");
            Map(x => x.TimeStamp).Column("TimeStamp");

            Table("tb_userdevicebind");
        }
    }
}
