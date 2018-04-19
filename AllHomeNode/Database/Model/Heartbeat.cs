using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model
{
    class Heartbeat
    {
        public virtual int Id { get; set; }
        public virtual string DeviceId { get; set; }
        public virtual string SoftwareVersion { get; set; }
        public virtual string HardwareVersion { get; set; }
        public virtual DateTime DeviceTime { get; set; }
        public virtual DateTime TimeStamp { get; set; }
    }
}
