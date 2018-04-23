using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Service.MQTT.Device
{
    public class VENT_EAWADA : DEVICE
    {
        public static int RegisterCount = 40;

        public enum ONOFF
        {
            OFF = 0,
            ON = 1
        }

        public enum FANSPEED
        {
            STOP = 0,
            LOW = 1,
            MIDDLE = 2,
            HIGH = 3
        }

        public enum CIRCLEMODE
        {
            INNER = 0,
            OUTER = 1
        }

        public enum AUTOMODE
        {
            MANUAL = 0,
            AUTO = 1
        }

        public enum CONTROLPOINT
        {
            ONOFF = 0,          // 0:关机 1:开机
            FAN_SPEED = 1,      // 0:停止 1:低速 2:中速 3:高速
            CIRCLE_MODE = 2,    // 0:内循环 1:外循环
            AUTO_MODE = 3,      // 0:手动 1:自动
            INNER_PM25 = 4,     // 只读
            INNER_CO2 = 5,      // 只读
            INNER_TEMP = 6,     // 只读
            INNER_HUMI = 7,     // 只读
            FANOUT_PM25 = 8,    // 只读
            FANOUT_TEMP = 9,    // 只读
            FANOUT_HUMI = 10,   // 只读
            LOWSPEED_INNERCIRCLETIME_L = 11,
            LOWSPEED_INNERCIRCLETIME_H = 12,
            MIDSPEED_INNERCIRCLETIME_L = 13,
            MIDSPEED_INNERCIRCLETIME_H = 14,
            HISPEED_INNERCIRCLETIME_L = 15,
            HISPEED_INNERCIRCLETIME_H = 16,
            LOWSPEED_OUTERCIRCLETIME_L = 17,
            LOWSPEED_OUTERCIRCLETIME_H = 18,
            MIDSPEED_OUTERCIRCLETIME_L = 19,
            MIDSPEED_OUTERCIRCLETIME_H = 20,
            HISPEED_OUTERCIRCLETIME_L = 21,
            HISPEED_OUTERCIRCLETIME_H = 22,
            TOTAL_TIME_L = 23,
            TOTAL_TIME_H = 24,
            ERROR_CODE = 25,
            FILTER_DUSTWEIGHT_L = 26,
            FILTER_DUSTWEIGHT_H = 27,
            FILTER_DUSTWARNINGWEIGHT_L = 28,
            FILTER_DUSTWARNINGWEIGHT_H = 29,
            CONDITION_AUTOMODE_CIRCLEMODE_PM25 = 30,
            CONDITION_AUTOMODE_CIRCLEMODE_CO2 = 31,
            CONDITION_AUTOMODE_FANSPEED_PM25 = 32,
            CONDITION_AUTOMODE_FANSPEED_CO2 = 33,
            DUSTWEIGHT_NOW_L = 34,
            DUSTWEIGHT_NOW_H = 35,
            TOTALWEIGHT_L_0 = 36,
            TOTALWEIGHT_L_1 = 37,
            TOTALWEIGHT_H_0 = 38,
            TOTALWEIGHT_H_1 = 39,
            UPLOAD_ALL_DATA = 0xFFFF
        }

        public static VENT_EAWADA GetDataObj(string deviceId, double[] data)
        {
            VENT_EAWADA obj = new VENT_EAWADA();

            obj.DeviceId = deviceId;

            obj._ONOFF = data[0];
            obj._FAN_SPD = data[1];      // 0:停止 1:低速 2:中速 3:高速
            obj._CIRCLE_MODE = data[2];    // 0:内循环 1:外循环
            obj._AUTO_MODE = data[3];     // 0:手动 1:自动
            obj._INNER_PM25 = data[4];    // 只读
            obj._INNER_CO2 = data[5];      // 只读
            obj._INNER_TEMP = data[6];     // 只读
            obj._INNER_HUMI = data[7];     // 只读
            obj._FANOUT_PM25 = data[8];  // 只读
            obj._FANOUT_TEMP = data[9];    // 只读
            obj._FANOUT_HUMI = data[10];    // 只读
            obj._LOWSPD_INNERCIRCLETIME_L = data[11];
            obj._LOWSPD_INNERCIRCLETIME_H = data[12];
            obj._MIDSPD_INNERCIRCLETIME_L = data[13];
            obj._MIDSPD_INNERCIRCLETIME_H = data[14];
            obj._HISPD_INNERCIRCLETIME_L = data[15];
            obj._HISPD_INNERCIRCLETIME_H = data[16];
            obj._LOWSPD_OUTERCIRCLETIME_L = data[17];
            obj._LOWSPD_OUTERCIRCLETIME_H = data[18];
            obj._MIDSPD_OUTERCIRCLETIME_L = data[19];
            obj._MIDSPD_OUTERCIRCLETIME_H = data[20];
            obj._HISPD_OUTERCIRCLETIME_L = data[21];
            obj._HISPD_OUTERCIRCLETIME_H = data[22];
            obj._TOTAL_TIME_L = data[23];
            obj._TOTAL_TIME_H = data[24];
            obj._ERR_CODE = data[25];
            obj._FILTER_DUSTWT_L = data[26];
            obj._FILTER_DUSTWT_H = data[27];
            obj._FILTER_DUSTWARNWT_L = data[28];
            obj._FILTER_DUSTWARNWT_H = data[29];
            obj._CONDITION_AUTO_CIRCLEMODE_PM25 = data[30];
            obj._CONDITION_AUTO_CIRCLEMODE_CO2 = data[31];
            obj._CONDITION_AUTO_FANSPEED_PM25 = data[32];
            obj._CONDITION_AUTO_FANSPEED_CO2 = data[33];
            obj._DUSTWT_NOW_L = data[34];
            obj._DUSTWT_NOW_H = data[35];
            obj._TOTALWT_L_0 = data[36];
            obj._TOTALWT_L_1 = data[37];
            obj._TOTALWT_H_0 = data[38];
            obj._TOTALWT_H_1 = data[39];

            return obj;
        }

        public double _ONOFF { get; set; }             // 0:关机 1:开机
        public double _FAN_SPD { get; set; }           // 0:停止 1:低速 2:中速 3:高速
        public double _CIRCLE_MODE { get; set; }       // 0:内循环 1:外循环
        public double _AUTO_MODE { get; set; }         // 0:手动 1:自动
        public double _INNER_PM25 { get; set; }        // 只读
        public double _INNER_CO2 { get; set; }         // 只读
        public double _INNER_TEMP { get; set; }        // 只读
        public double _INNER_HUMI { get; set; }        // 只读
        public double _FANOUT_PM25 { get; set; }       // 只读
        public double _FANOUT_TEMP { get; set; }       // 只读
        public double _FANOUT_HUMI { get; set; }       // 只读
        public double _LOWSPD_INNERCIRCLETIME_L { get; set; }
        public double _LOWSPD_INNERCIRCLETIME_H { get; set; }
        public double _MIDSPD_INNERCIRCLETIME_L { get; set; }
        public double _MIDSPD_INNERCIRCLETIME_H { get; set; }
        public double _HISPD_INNERCIRCLETIME_L { get; set; }
        public double _HISPD_INNERCIRCLETIME_H { get; set; }
        public double _LOWSPD_OUTERCIRCLETIME_L { get; set; }
        public double _LOWSPD_OUTERCIRCLETIME_H { get; set; }
        public double _MIDSPD_OUTERCIRCLETIME_L { get; set; }
        public double _MIDSPD_OUTERCIRCLETIME_H { get; set; }
        public double _HISPD_OUTERCIRCLETIME_L { get; set; }
        public double _HISPD_OUTERCIRCLETIME_H { get; set; }
        public double _TOTAL_TIME_L { get; set; }
        public double _TOTAL_TIME_H { get; set; }
        public double _ERR_CODE { get; set; }
        public double _FILTER_DUSTWT_L { get; set; }
        public double _FILTER_DUSTWT_H { get; set; }
        public double _FILTER_DUSTWARNWT_L { get; set; }
        public double _FILTER_DUSTWARNWT_H { get; set; }
        public double _CONDITION_AUTO_CIRCLEMODE_PM25 { get; set; }
        public double _CONDITION_AUTO_CIRCLEMODE_CO2 { get; set; }
        public double _CONDITION_AUTO_FANSPEED_PM25 { get; set; }
        public double _CONDITION_AUTO_FANSPEED_CO2 { get; set; }
        public double _DUSTWT_NOW_L { get; set; }
        public double _DUSTWT_NOW_H { get; set; }
        public double _TOTALWT_L_0 { get; set; }
        public double _TOTALWT_L_1 { get; set; }
        public double _TOTALWT_H_0 { get; set; }
        public double _TOTALWT_H_1 { get; set; }
    }
}
