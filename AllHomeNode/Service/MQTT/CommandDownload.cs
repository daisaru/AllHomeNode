using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeNode.Service.MQTT
{
    public class CommandDownload
    {
        public string Code { get; set; }
        public Enums.METHOD Method { get; set; }
        public string Value { get; set; }

        public Enums.MODE Mode { get; set; }
        public ModeParas ModeParameter { get; set; }
        public string DeviceToken { get; set; }
        public string TimeStamp { get; set; }   // 时间戳

        public CommandDownload()
        {
            ModeParameter = new ModeParas();
        }
    }

    //请求:

    //{
    //    "Code": "ee6a13575d244a5cbe021f29ca1b41f4",
    //    "Method": 1,
    //    "Value": "0"
    //    "Mode": 1,
    //    "ModeParameter": {
    //        "ModeAction": 0,
    //        "ModeId": "",
    //        "ModeSubType": 0,
    //        "HH": 0,
    //        "MM": 0,
    //        "WeekDay": "",
    //        "Code": "",
    //        "Condition": 0,
    //        "Value": "",
    //        "Repeat": false
    //    },
    //    "DeviceToken": "",
    //    "TimeStamp": "2018-01-01 00:00:00"
    //}

    //Method字段：
    //    Method=0: 读单个控制点数据，此时Value字段为空；
    //    Method=1: 写单个控制点数据，此时Value字段为要写入的值，写成功后会返回当前值；

    //Mode字段: 
    //    0: 保留。
    //    1：实时模式：对外围设备实时下发读、写指令并得到返回；
    //    2: 本地模式：定时，事件，时间事件，以及本地一些功能控制；
    //    3：场景模式：预定义的场景模式，网关设备内部预定义的工作模式，直接调用即可立即执行；

    //ModeParameter：不同模式下的参数配置；
    //    ModeAction：针对某一模式的操作；
    //        RESERVE = 0,
    //        REGISTERANDSTART = 1,   注册并启动；
    //        UNREGISTERANDSTOP = 2,  取消注册并停止；
    //        START = 3,              启动；
    //        STOP = 4,               停止；

    //    ModeId：模式的唯一标识符，由移动应用生成并保存，用于对模式进行操作；

    //    ModeSubType：模式的子类型。
    //        RESERVE = 0,            保留；
    //        TIME = 1,               定时，下发的读写指令在预订时间触发并返回；
    //        EVENT = 2,              事件触发，下发的读写指令在条件发生时触发执行并返回；
    //        EVENTONTIME = 3,        定时事件触发，下发的读写指令在预定时间和事件条件均满足时触发执行并返回；
    //        ADMIN = 4               本地管理；

    //    HH：        定时/定时事件，小时；
    //    MM：        定时/定时事件，分钟；
    //    WeekDay:    定时/定时事件，日期，“x-x-x-x-x-x-x”，x为周日到周六是否执行（0/1）；    

    //    Code：      条件/定时条件，控制点
    //    Condition： 条件/定时条件，条件
    //        0：等于
    //        1：不等于
    //        2：大于
    //        3：大于等于
    //        4：小于
    //        5：小于等于
    //    Value：     条件/定时条件，对比值，根据实际情况进行赋值；

    //    Repeat：    定时/定时事件/条件，模式（TIME/EVENT/EVENTONTIME）是否重复执行；


    //    预定义场景模式：
    //    ModePatameter：
    //    Code字段内容定义如下：
    //      0: 手动模式
    //      1：离家模式
    //      2：居家模式
    //      3：度假模式
    //    Method字段内容定义如下：
    //      1：启动模式并返回当前模式
    //      0：返回当前模式
    //    Value字段为空“”。


    //TimeStamp: 当前服务器时间。

}
