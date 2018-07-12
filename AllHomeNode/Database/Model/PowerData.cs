using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model
{
    class PowerData
    {
        public virtual int Id { get; set; }
        public virtual string GatewayId { get; set; }
        public virtual string CPCode { get; set; }
        public virtual string PowerConsume { get; set; }
        public virtual string PowerType { get; set; }
        public virtual DateTime TimeStamp { get; set; }
    }
}
