﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Front
{
    public class RoomData
    {
        public RoomData()
        {
            ControlPoints = new List<ControlPointData>();
        }
        public string Name { get; set; }
        public string Size { get; set; }
        public List<ControlPointData> ControlPoints {get;set;}
    }
}
