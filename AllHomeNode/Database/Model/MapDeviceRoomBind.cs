using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model
{
    class MapDeviceRoomBind : ClassMap<DeviceRoomBind>
    {
        public MapDeviceRoomBind()
        {
            Id(x => x.Id).Column("Id");

            Map(x => x.Id_Device).Column("Id_Device");
            Map(x => x.Id_Room).Column("Id_Room");
            Map(x => x.TimeStamp).Column("TimeStamp");

            Table("tb_deviceroombind");
        }
    }
}
