using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model
{
    class ControlPoint
    {
        public virtual string Id { get; set; }
        public virtual string Id_Room { get; set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual string Type { get; set; }
        public virtual string Point { get; set; }
        public virtual string Brand { get; set; }
        public virtual string Model { get; set; }
        public virtual DateTime TimeStamp { get; set; }
    }
}
