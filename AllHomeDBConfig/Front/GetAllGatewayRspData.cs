using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallationTool.Front
{
    public class GetAllGatewayRspData
    {
        public string Result { get; set; }
        public List<UserGatewayData> Gateway { get; set; }
    }
}
