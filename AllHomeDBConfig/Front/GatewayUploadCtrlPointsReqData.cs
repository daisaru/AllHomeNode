using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallationTool.Front
{
    public class GatewayUploadCtrlPointsReqData
    {
        public string GatewayId { get; set; }
        public List<DeviceData> Device { get; set; }
        public string Signature { get; set; }
    }
}
