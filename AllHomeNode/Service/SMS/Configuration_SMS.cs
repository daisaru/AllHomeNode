using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Service.SMS
{
    public class Configuration_SMS
    {
        public int AppId { get; set; }
        public string AppKey { get; set; }
        public int TemplateId { get; set; } 
        public string SignatureName { get; set; }
    }
}
