using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.model.controlpoints
{
    public enum Vent_EAWADA
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
        TOTALWEIGHT_H_1 = 39
    }
}
