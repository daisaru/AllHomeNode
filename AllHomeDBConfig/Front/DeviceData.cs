using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallationTool.Front
{
    public class DeviceData
    {
        public DeviceData()
        {
            ControlPoints = new List<ControlPointData>();
        }
        public string DeviceId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<ControlPointData> ControlPoints { get; set; }
    }
}
