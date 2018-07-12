﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Front
{
    public class HeartbeatData
    {
        public string Id { get; set; }
        public string GatewayId { get; set; }
        public string SoftwareVersion { get; set; }
        public string HardwareVersion { get; set; }
        public DateTime GatewayTime { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
