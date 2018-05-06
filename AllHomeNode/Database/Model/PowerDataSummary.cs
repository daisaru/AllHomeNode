using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Database.Model
{
    class PowerDataSummary
    {
        public virtual int Id { get; set; }
        public virtual string DeviceId { get; set; }
        public virtual string Light { get; set; }
        public virtual string Air { get; set; }
        public virtual string Total { get; set; }
        public virtual DateTime SummaryTime{ get; set; }
        public virtual int IsMonth { get; set; }
        public virtual DateTime TimeStamp { get; set; }
    }
}
