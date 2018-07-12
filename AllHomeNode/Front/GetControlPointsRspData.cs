using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Front
{
    public class GetControlPointsRspData
    {
        public GetControlPointsRspData()
        {
            Device = new List<DeviceData>();
        }
        public string Result { get; set; }
        public List<DeviceData> Device { get; set; }
    }
}
