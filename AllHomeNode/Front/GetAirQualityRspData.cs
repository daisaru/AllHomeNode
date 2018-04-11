using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Front
{
    public class GetAirQualityRspData
    {
        public string Result { get; set; }
        public List<AirQualityData> AirQuality { get; set; }
    }
}
