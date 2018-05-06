using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model
{
    class MapPowerDataSummary : ClassMap<PowerDataSummary>
    {
        MapPowerDataSummary()
        {
            Id(x => x.Id).Column("Id");

            Map(x => x.DeviceId).Column("DeviceId");
            Map(x => x.Light).Column("Light");
            Map(x => x.Air).Column("Air");
            Map(x => x.Total).Column("Total");
            Map(x => x.SummaryTime).Column("SummaryTime");
            Map(x => x.IsMonth).Column("IsMonth");
            Map(x => x.TimeStamp).Column("TimeStamp");

            Table("tb_powerdata_summary");
        }
    }
}
