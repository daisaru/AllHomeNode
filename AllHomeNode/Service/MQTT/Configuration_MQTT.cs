using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Service.MQTT
{
    public class Configuration_MQTT
    {
        public string BrokerURL { set; get; }
        public int Port { set; get; }
        public string ClientID { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
        public string ReceiveTopic { set; get; }
    }
}
