using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Front
{
    public class GetGatewayTokenRspData
    {
        public string Result { get; set; }
        public string GatewayToken { get; set; }
        public string GatewayTokenLife { get; set; }
        public string TimeStamp { get; set; }
    }
}
