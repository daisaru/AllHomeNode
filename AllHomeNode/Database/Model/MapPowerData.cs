using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model
{
    class MapPowerData : ClassMap<PowerData>
    {
        MapPowerData()
        {
            Id(x => x.Id).Column("Id");

            Map(x => x.DeviceId).Column("DeviceId");
            Map(x => x.CPCode).Column("CPCode");
            Map(x => x.PowerConsume).Column("PowerConsume");
            Map(x => x.PowerType).Column("PowerType");
            Map(x => x.TimeStamp).Column("TimeStamp");

            Table("tb_powerdata");
        }
    }
}
