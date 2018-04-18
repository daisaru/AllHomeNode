using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Service.MQTT
{
    public class CommandHelper
    {
        private static CommandHelper _instance = null;

        private CommandHelper()
        {

        }

        public static CommandHelper Instance()
        {
            if (_instance == null)
                _instance = new CommandHelper();
                return _instance;
        }

        public CommandDownload GetTimeSyncCommand()
        {
            CommandDownload cmd = new CommandDownload();
            cmd.Code = FIXEDCONTROLPOINTS.TIMESYNC;
            cmd.Method = Enums.METHOD.WRITEREAD;
            cmd.Mode = Enums.MODE.LOCAL;
            cmd.ModeParameter.ModeSubType = Enums.MODESUBTYPE.ADMIN;
            cmd.DeviceToken = "";
            cmd.Value = DateTime.Now.ToString();
            cmd.TimeStamp = DateTime.Now.ToString();

            return cmd;
        }
    }
}
