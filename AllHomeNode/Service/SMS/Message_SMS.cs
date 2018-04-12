using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Service.SMS
{
    public class Message_SMS
    {
        public string Mobile { get; set; }
        public string RandomCode { get; set; }
        public int LifeTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Send { get; set; }
    }
}
