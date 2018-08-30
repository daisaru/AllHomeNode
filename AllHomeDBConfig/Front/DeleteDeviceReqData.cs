using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallationTool.Front
{
    public class DeleteDeviceReqData
    {
        public string Mobile { get; set; }
        public string GatewayId { get; set; }
        public string DeviceId { get; set; }
        public string Token { get; set; }
    }
}
