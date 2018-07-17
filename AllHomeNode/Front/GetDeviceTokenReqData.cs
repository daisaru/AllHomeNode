using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Front
{
    public class GetGatewayTokenReqData
    {
        public string Mobile { get; set; }
        public string GatewayId { get; set; }
        public string Token { get; set; }
        public string DeviceOldToken { get; set; }
    }
}
