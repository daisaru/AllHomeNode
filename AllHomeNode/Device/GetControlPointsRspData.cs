using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.model
{
    public class GetControlPointsRspData
    {
        public GetControlPointsRspData()
        {
            Rooms = new List<RoomData>();
        }
        public string Result { get; set; }
        public List<RoomData> Rooms { get; set; }
    }
}
