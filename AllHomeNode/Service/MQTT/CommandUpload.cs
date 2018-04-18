using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Service.MQTT
{
    public class CommandUpload
    {
        public string Result { get; set; }

        public string Code { get; set; }
        public Enums.METHOD Method { get; set; }
        public string Value { get; set; }
        public Enums.MODE Mode { get; set; }
        public ModeParas ModeParameter { get; set; }
        public string DeviceToken { get; set; }

        public string Data { get; set; }

        public string TimeStamp { get; set; }   // 时间戳

        public CommandUpload()
        {
            ModeParameter = new ModeParas();
        }
    }
}
