using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Service.MQTT
{
    public class FIXEDCONTROLPOINTS
    {
        public const string TIMESYNC = "LOCALSERVICE_0000000000000000001";
        public const string UPGRADE = "LOCALSERVICE_0000000000000000002";
    }
    public class Enums
    {
        public enum METHOD
        {
            READ = 0,
            WRITEREAD = 1,
        }

        public enum MODE
        {
            RESERVE = 0,
            REALTIME = 1,
            TIME = 2,
            EVENT = 3,
            TIMEANDEVENT = 4,
            SENARIO = 5,
            ADMIN = 6
        }
    }
}
