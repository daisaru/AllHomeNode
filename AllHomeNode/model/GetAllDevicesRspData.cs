﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.model
{
    public class GetAllDevicesRspData
    {
        public string Result { get; set; }
        public List<UserDeviceData> Devices { get; set; }
    }
}
