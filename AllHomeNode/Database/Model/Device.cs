using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model
{
    class Device
    {
        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Type { get; set; }
        public virtual DateTime TimeStamp { get; set; }
    }
}
