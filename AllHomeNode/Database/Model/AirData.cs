using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model
{
    class AirData
    {
        public virtual int Id { get; set; }
        public virtual string DeviceId { get; set; }
        public virtual string ONOFF { get; set; }
        public virtual string FAN_SPEED { get; set; }
        public virtual string CIRCLE_MODE { get; set; }
        public virtual string AUTO_MODE { get; set; }
        public virtual string INNER_PM25 { get; set; }
        public virtual string INNER_CO2 { get; set; }
        public virtual string INNER_TEMP { get; set; }
        public virtual string INNER_HUMI { get; set; }
        public virtual string FANOUT_PM25 { get; set; }
        public virtual string FANOUT_TEMP { get; set; }
        public virtual string FANOUT_HUMI { get; set; }
        public virtual string LOWSPEED_INNERCIRCLETIME_L { get; set; }
        public virtual string LOWSPEED_INNERCIRCLETIME_H { get; set; }
        public virtual string MIDSPEED_INNERCIRCLETIME_L { get; set; }
        public virtual string MIDSPEED_INNERCIRCLETIME_H { get; set; }
        public virtual string HISPEED_INNERCIRCLETIME_L { get; set; }
        public virtual string HISPEED_INNERCIRCLETIME_H { get; set; }
        public virtual string LOWSPEED_OUTERCIRCLETIME_L { get; set; }
        public virtual string LOWSPEED_OUTERCIRCLETIME_H { get; set; }
        public virtual string MIDSPEED_OUTERCIRCLETIME_L { get; set; }
        public virtual string MIDSPEED_OUTERCIRCLETIME_H { get; set; }
        public virtual string HISPEED_OUTERCIRCLETIME_L { get; set; }
        public virtual string HISPEED_OUTERCIRCLETIME_H { get; set; }
        public virtual string TOTAL_TIME_L { get; set; }
        public virtual string TOTAL_TIME_H { get; set; }
        public virtual string ERROR_CODE { get; set; }
        public virtual string FILTER_DUSTWEIGHT_L { get; set; }
        public virtual string FILTER_DUSTWEIGHT_H { get; set; }
        public virtual string FILTER_DUSTWARNINGWEIGHT_L { get; set; }
        public virtual string FILTER_DUSTWARNINGWEIGHT_H { get; set; }
        public virtual string CONDITION_AUTOMODE_CIRCLEMODE_PM25 { get; set; }
        public virtual string CONDITION_AUTOMODE_CIRCLEMODE_CO2 { get; set; }
        public virtual string CONDITION_AUTOMODE_FANSPEED_PM25 { get; set; }
        public virtual string CONDITION_AUTOMODE_FANSPEED_CO2 { get; set; }
        public virtual string DUSTWEIGHT_NOW_L { get; set; }
        public virtual string DUSTWEIGHT_NOW_H { get; set; }
        public virtual string TOTALWEIGHT_L_0 { get; set; }
        public virtual string TOTALWEIGHT_L_1 { get; set; }
        public virtual string TOTALWEIGHT_H_0 { get; set; }
        public virtual string TOTALWEIGHT_H_1 { get; set; }
        public virtual DateTime TimeStamp { get; set; }
    }
}
