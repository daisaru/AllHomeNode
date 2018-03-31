using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Front
{
    public class GetDeviceTokenReqData
    {
        public string Mobile { get; set; }
        public string DeviceId { get; set; }
        public string Token { get; set; }
        public string DeviceOldToken { get; set; }
    }
}
