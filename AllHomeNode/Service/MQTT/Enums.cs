﻿using System;
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
        public enum REGISTERGROUP
        {
            RESERVE = 0,                // 自定义功能点
            COMMONREGISTER = 1,         // 非标准的RS485寄存器功能点
            COIL = 2,                   // 标准Modbus线圈
            INPUTREGISTER = 3,          // 标准Modbus输入寄存器
            HOLDINGREGISTER = 4         // 标准Modbus保持寄存器
        }

        public enum POWERCONSUMERTYPE
        {
            RESERVE = 0,
            LIGHT = 1,          // 照明
            AIRCONTROL = 2,     // 空调
        }

        public enum DEVICEBRAND
        {
            RESERVE = 0,
            JADECORE = 1,        // JadeCore
            EAWADA = 2,          // EAWADA
            JSY = 3,             // 健思研
            LINESHOW = 4,        // 蓝释
            YILIN = 5            // 福建亿林
        }

        public enum DEVICETYPE
        {
            GATEWAY = 0,    // 智能网关 
            LIGHT = 1,      // 灯光   
            AUDIO = 2,      // 背景音乐  
            AIRCON = 3,     // 空调     
            VENT = 4,       // 新风系统  
            POWER = 5       // 电量计量
        }

        public enum PORTFUNC
        {
            LOCAL = 0,
            RS232_A = 1,
            RS232_B = 2,
            RS485 = 3,
            MODBUS = 4,
            MQTT = 5,
            SENARIO = 6
        }

        public enum METHOD
        {
            READ = 0,
            WRITEREAD = 1,
        }

        public enum MODE
        {
            RESERVE = 0,
            REALTIME = 1,
            LOCAL = 2,
            SENARIO = 3
        }

        public enum MODEACTION
        {
            RESERVE = 0,
            REGISTERANDSTART = 1,
            UNREGISTERANDSTOP = 2,
            START = 3,
            STOP = 4
        }

        public enum MODESUBTYPE
        {
            RESERVE = 0,
            TIME = 1,
            EVENT = 2,
            EVENTONTIME = 3,
            ADMIN = 4,
            CIRCLE = 5
        }

        public enum EVENTCONDITION
        {
            EQUAL = 0,
            NOTEQUAL = 1,
            MORE = 2,
            MOREOREQUAL = 3,
            LESS = 4,
            LESSOREQUAL = 5
        }

        public enum ENDPOINT
        {
            LOCAL = 0,
            DEVICE = 1,
            SERVER = 2,
            MOBILE = 3
        }

        public enum SENARIO
        {
            MANUAL = 0,
            INHOME = 1,
            OUTHOME = 2,
            TRAVEL = 3
        }
    }
}
