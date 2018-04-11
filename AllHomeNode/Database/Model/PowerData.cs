﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model
{
    class PowerData
    {
        public virtual string Id { get; set; }
        public virtual string DeviceId { get; set; }
        public virtual string PowerConsume { get; set; }
        public virtual DateTime TimeStamp { get; set; }
    }
}
