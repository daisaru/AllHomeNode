using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model
{
    class MapAirData : ClassMap<AirData>
    {
        MapAirData()
        {
            Id(x => x.Id).Column("Id");

            Map(x => x.GatewayId).Column("GatewayId");
            Map(x => x.ONOFF).Column("ONOFF");
            Map(x => x.FAN_SPEED).Column("FAN_SPEED");
            Map(x => x.CIRCLE_MODE).Column("CIRCLE_MODE");
            Map(x => x.AUTO_MODE).Column("AUTO_MODE");
            Map(x => x.INNER_PM25).Column("INNER_PM25");
            Map(x => x.INNER_CO2).Column("INNER_CO2");
            Map(x => x.INNER_TEMP).Column("INNER_TEMP");
            Map(x => x.INNER_HUMI).Column("INNER_HUMI");
            Map(x => x.FANOUT_PM25).Column("FANOUT_PM25");
            Map(x => x.FANOUT_TEMP).Column("FANOUT_TEMP");
            Map(x => x.FANOUT_HUMI).Column("FANOUT_HUMI");
            Map(x => x.LOWSPEED_INNERCIRCLETIME_L).Column("LOWSPEED_INNERCIRCLETIME_L");
            Map(x => x.LOWSPEED_INNERCIRCLETIME_H).Column("LOWSPEED_INNERCIRCLETIME_H");
            Map(x => x.MIDSPEED_INNERCIRCLETIME_L).Column("MIDSPEED_INNERCIRCLETIME_L");
            Map(x => x.MIDSPEED_INNERCIRCLETIME_H).Column("MIDSPEED_INNERCIRCLETIME_H");
            Map(x => x.HISPEED_INNERCIRCLETIME_L).Column("HISPEED_INNERCIRCLETIME_L");
            Map(x => x.HISPEED_INNERCIRCLETIME_H).Column("HISPEED_INNERCIRCLETIME_H");
            Map(x => x.LOWSPEED_OUTERCIRCLETIME_L).Column("LOWSPEED_OUTERCIRCLETIME_L");
            Map(x => x.LOWSPEED_OUTERCIRCLETIME_H).Column("LOWSPEED_OUTERCIRCLETIME_H");
            Map(x => x.MIDSPEED_OUTERCIRCLETIME_L).Column("MIDSPEED_OUTERCIRCLETIME_L");
            Map(x => x.MIDSPEED_OUTERCIRCLETIME_H).Column("MIDSPEED_OUTERCIRCLETIME_H");
            Map(x => x.HISPEED_OUTERCIRCLETIME_L).Column("HISPEED_OUTERCIRCLETIME_L");
            Map(x => x.HISPEED_OUTERCIRCLETIME_H).Column("HISPEED_OUTERCIRCLETIME_H");
            Map(x => x.TOTAL_TIME_L).Column("TOTAL_TIME_L");
            Map(x => x.TOTAL_TIME_H).Column("TOTAL_TIME_H");
            Map(x => x.ERROR_CODE).Column("ERROR_CODE");
            Map(x => x.FILTER_DUSTWEIGHT_L).Column("FILTER_DUSTWEIGHT_L");
            Map(x => x.FILTER_DUSTWEIGHT_H).Column("FILTER_DUSTWEIGHT_H");
            Map(x => x.FILTER_DUSTWARNINGWEIGHT_L).Column("FILTER_DUSTWARNINGWEIGHT_L");
            Map(x => x.FILTER_DUSTWARNINGWEIGHT_H).Column("FILTER_DUSTWARNINGWEIGHT_H");
            Map(x => x.CONDITION_AUTOMODE_CIRCLEMODE_PM25).Column("CONDITION_AUTOMODE_CIRCLEMODE_PM25");
            Map(x => x.CONDITION_AUTOMODE_CIRCLEMODE_CO2).Column("CONDITION_AUTOMODE_CIRCLEMODE_CO2");
            Map(x => x.CONDITION_AUTOMODE_FANSPEED_PM25).Column("CONDITION_AUTOMODE_FANSPEED_PM25");
            Map(x => x.CONDITION_AUTOMODE_FANSPEED_CO2).Column("CONDITION_AUTOMODE_FANSPEED_CO2");
            Map(x => x.DUSTWEIGHT_NOW_L).Column("DUSTWEIGHT_NOW_L");
            Map(x => x.DUSTWEIGHT_NOW_H).Column("DUSTWEIGHT_NOW_H");
            Map(x => x.TOTALWEIGHT_L_0).Column("TOTALWEIGHT_L_0");
            Map(x => x.TOTALWEIGHT_L_1).Column("TOTALWEIGHT_L_1");
            Map(x => x.TOTALWEIGHT_H_0).Column("TOTALWEIGHT_H_0");
            Map(x => x.TOTALWEIGHT_H_1).Column("TOTALWEIGHT_H_1");
            Map(x => x.OUTSIDE_HUMI).Column("OUTSIDE_HUMI");
            Map(x => x.OUTSIDE_TEMP).Column("OUTSIDE_TEMP");
            Map(x => x.OUTSIDE_PM25).Column("OUTSIDE_PM25");

            Map(x => x.TimeStamp).Column("TimeStamp");

            Table("tb_airdata");
        }
    }
}
