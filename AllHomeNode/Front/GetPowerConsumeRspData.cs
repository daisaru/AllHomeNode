using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Front
{
    public class GetPowerConsumeRspData
    {
        public string Result { get; set; }
        public List<PowerConsumeData> PowerConsume { get; set; }
    }
}
