using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Front
{
    public class AirQualityData
    {
        public string INNER_PM25 { get; set; }
        public string INNER_CO2 { get; set; }
        public string INNER_TEMP { get; set; }
        public string INNER_HUMI { get; set; }
        public string FANOUT_PM25 { get; set; }
        public string FANOUT_TEMP { get; set; }
        public string FANOUT_HUMI { get; set; }
        public string TimeStamp { get; set; }
    }
}
