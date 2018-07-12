using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Front
{
    public class GatewayUploadCtrlPointsReqData
    {
        public string GatewayId { get; set; }
        public List<DeviceData> Rooms { get; set; }
        public string Signature { get; set; }
    }
}
