﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model
{
    class Room
    {
        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Size { get; set; }
        public virtual DateTime TimeStamp { get; set; }
    }
}
