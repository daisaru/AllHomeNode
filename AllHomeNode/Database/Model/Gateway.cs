using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model
{
    class Gateway
    {
        public virtual string Id { get; set; }
        public virtual string GatewayId { get; set; }
        public virtual string GatewayName { get; set; }
        public virtual DateTime TimeStamp { get; set; }
    }
}
