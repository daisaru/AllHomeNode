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
        public string Method { get; set; }
        public string Value { get; set; }
        public string Mode { get; set; }
        public string ModeParameter { get; set; }
        public string DeviceToken { get; set; }
        public string TimeStamp { get; set; }   // 时间戳
    }

    //请求:

    //{
    //    "Code": "e4b41f50d56a43a4a8d945cadbe9e15e",
    //    "Method": "1",
    //    "Value": "1",
    //    "Mode": "1",
    //    "ModePatameter": "hh:mm x-x-x-x-x-x-x r",
    //    "DeviceToken": "sfaewgwetwrwr23dsfs",
    //    "TimeStamp": "2018/01/01 00:00:00"
    //}

    //Method字段：
    //Method=0: 读单个控制点数据，此时Value字段为空；
    //Method=1: 写单个控制点数据，此时Value字段为要写入的值；

    //Mode字段: 
    //0: 保留，目前为内部流转模式。
    //1：实时模式，实时下发读、写指令并得到返回；
    //2：定时模式，下发的读写指令在预订时间触发并返回；
    //    ModePatameter字段：“hh mm x-x-x-x-x-x-x r”，hh为小时，取值0-24，mm为分钟，取值0-59，x为周日到周六是否执行（0/1），r为是否循环（0/1）； 
    //3：事件触发模式，下发的读写指令在条件发生时触发执行并返回；
    //    ModePatameter字段：“code condition value”，code为事件触发的控制点，condition为条件，value为条件取值；
    //    Condition:
    //        0：等于
    //        1：不等于
    //        2：大于
    //        3：大于等于
    //        4：小于
    //        5：小于等于
    //    value：根据实际情况进行赋值；
    //4：定时+事件触发模式，下发的读写指令在预定时间和事件条件均满足时触发执行并返回；
    //    ModePatameter字段：“hh mm x-x-x-x-x-x-x r code condition value”，code为事件触发的控制点，condition为条件，value为条件取值；
    //5：预定义模式：网关设备内部预定义的工作模式，直接调用即可。
    //    ModePatameter字段：“”
    //    code字段内容定义如下：
    //      0: 手动模式
    //      1：离家模式
    //      2：居家模式
    //      3：度假模式
    //    Method字段内容定义如下：
    //      1：设置模式并返回当前模式
    //      0：获取当前模式
    //    Value字段为空“”。


    //TimeStamp: 当前服务器时间。
}
