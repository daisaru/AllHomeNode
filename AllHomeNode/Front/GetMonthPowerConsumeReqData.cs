using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Front
{
    public class GetMonthPowerConsumeReqData
    {
        public string Mobile { get; set; }
        public string GatewayId { get; set; }
        public string Token { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsDetail { get; set; }
    }
}
