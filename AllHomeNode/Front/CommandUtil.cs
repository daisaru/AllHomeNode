using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Front
{
    public class CommandUtil
    {
        public static class RETURN
        {
            public static string SUCCESS = "Success";
            public static string ERROR_UNKNOW = "E00000";
            public static string ERROR_TOKEN_INVALID = "E00001";
            public static string ERROR_RANDOMCODE_INVALID = "E00002";
            public static string ERROR_NO_PRIVILEGE = "E00003";
            public static string ERROR_SERVICE_UNAVAILABLE = "E00004";
            public static string ERROR_DATABASE_ERROR = "E00005";

            public static string ERROR_USER_MOBILEUSED = "E10001";  //手机号已经被使用
            public static string ERROR_USER_NOTFOUND = "E10002";    //用户不存在
            public static string ERROR_USER_LOGINFAILED = "E10003"; //用户名或密码不正确
        }

        public static class PRIVILEGE
        {
            public static string READ = "Read";
            public static string CONTROL = "Control";
            public static string ADMIN = "Admin";
        }

        public static class CONTROLPOINT_TYPE
        {
            public static string OTHER = "Other";
            public static string LIGHT = "Light";
            public static string AUDIO = "Audio";
            public static string AIRCON = "AirCon";
            public static string VENT = "Vent";
            public static string ELEMETER = "EleMeter";
        }

        public static class DEVICE_TYPE
        {
            public static string GATEWAY = "GATEWAY";
            public static string AIRCON = "AIRCON";
            public static string VENT = "VENT";
            public static string CTRL_AIR = "CTRL_AIR";
            public static string CTRL_HEAT = "CTRL_HEAT";
            public static string METER_POWER = "METER_POWER";
        }

        public static class ONLINE_STATE
        {
            public static string ONLINE = "Online";
            public static string OFFLINE = "Offline";
        }

    }
}
