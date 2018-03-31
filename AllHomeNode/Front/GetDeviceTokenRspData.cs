using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Front
{
    public class GetDeviceTokenRspData
    {
        public string Result { get; set; }
        public string DeviceToken { get; set; }
        public string DeviceTokenLife { get; set; }
        public string TimeStamp { get; set; }
    }
}
