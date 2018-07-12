using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Front
{
    public class GetAllGatewayRspData
    {
        public string Result { get; set; }
        public List<UserGatewayData> Gateway { get; set; }
    }
}
