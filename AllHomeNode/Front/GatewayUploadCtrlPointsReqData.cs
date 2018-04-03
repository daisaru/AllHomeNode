using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Front
{
    public class GatewayUploadCtrlPointsReqData
    {
        public string DeviceId { get; set; }
        public List<RoomData> Rooms { get; set; }
        public string Signature { get; set; }
    }
}
