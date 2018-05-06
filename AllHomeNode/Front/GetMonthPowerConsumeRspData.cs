using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Front
{
    public class GetMonthPowerConsumeRspData
    {
        public string Result { get; set; }
        public string Power_Light { get; set; }
        public string Power_Air { get; set; }
        public string Power_Total { get; set; }
        public List<PowerConsumeData> PowerConsume { get; set; }
    }
}
