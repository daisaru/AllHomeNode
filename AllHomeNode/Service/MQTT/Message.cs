using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Service.MQTT
{
    public class Message
    {
        public string id { get; set; }
        public string topic { get; set; }
        public CommandDownload cmdDownload { get; set; }
        public CommandUpload cmdUpload { get; set; }
    }
}
