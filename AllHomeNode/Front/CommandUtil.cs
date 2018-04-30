﻿using System;
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

    }
}
