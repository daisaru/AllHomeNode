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
        public string Method { get; set; }
        public string Value { get; set; }
        public string Mode { get; set; }
        public string ModeParameter { get; set; }
        public string DeviceToken { get; set; }

        public string Data { get; set; }

        public string TimeStamp { get; set; }   // 时间戳

        public static CommandUpload GenerateRspObj(CommandDownload req)
        {
            CommandUpload rsp = new CommandUpload();
            //rsp.Result = ?
            rsp.Code = req.Code;
            rsp.Method = req.Method;
            rsp.Value = req.Value;
            rsp.Mode = req.Mode;
            rsp.ModeParameter = req.ModeParameter;
            rsp.DeviceToken = req.DeviceToken;
            rsp.Data = "";
            rsp.TimeStamp = DateTime.Now.ToString();

            return rsp;
        }
    }
}
