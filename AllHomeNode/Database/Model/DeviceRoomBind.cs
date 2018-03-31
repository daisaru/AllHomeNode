﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model

{
    class DeviceRoomBind
    {
        public virtual string Id { get; set; }
        public virtual string Id_Device { get; set; }
        public virtual string Id_Room { get; set; }
        public virtual DateTime TimeStamp { get; set; }
    }
}
