using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AllHomeNode.Service.MQTT;

namespace AllHomeNode.Service
{
    public class ModeParas
    {
        public Enums.MODEACTION ModeAction { get; set; }
        public string ModeId { get; set; }
        public Enums.MODESUBTYPE ModeSubType { get; set; }

        public int HH { get; set; }
        public int MM { get; set; }
        public string WeekDay { get; set; }

        public string Code { get; set; }
        public Enums.EVENTCONDITION Condition { get; set; }
        public string Value { get; set; }

        public bool Repeat { get; set; }
    }
}
