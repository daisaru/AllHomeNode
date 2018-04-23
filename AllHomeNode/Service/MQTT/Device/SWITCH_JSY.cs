using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static AllHomeNode.Service.MQTT.Enums;

namespace AllHomeNode.Service.MQTT.Device
{
    public class SWITCH_JSY : DEVICE
    {
        public static int RegisterCount = 14;

        // 设备编号（地址）
        // 控制码（寄存器）
        public enum CONTROLPOINT
        {
            POWERDATA = 1,      // 获取所有数据，只读，01
            ONOFF = 2,          // 0:拉闸 1:合闸，写/间接读，02
            BUYPOWER = 3,       // 购电，写/间接读，03
            UPLOAD_ALL_DATA = 0xFFFF    // 获取所有数据
        }

        public POWERCONSUMERTYPE ConsumerType = POWERCONSUMERTYPE.RESERVE;

        public double Voltage { get; set; }          // 电压
        public double Current { get; set; }          // 电流
        public double ActivePower { get; set; }      // 有功功率
        public double ReActivePower { get; set; }    // 无功功率
        public double ApparentPower { get; set; }    // 视在功率
        public double PowerFactor { get; set; }      // 功率因数
        public double Frequency { get; set; }        // 频率
        public double LeakCurrent { get; set; }      // 漏电流
        public double Temperature { get; set; }      // 温度
        public double Humidity { get; set; }         // 湿度
        public byte RelayStatus { get; set; }       // 继电器状态
        public byte WarningStatus { get; set; }     // 报警状态
        public double CurrentPower { get; set; }     // 当前电量
        public double BoughtPower { get; set; }      // 购买电量

        public static SWITCH_JSY GetDataObj(string deviceId, byte[] data)
        {
            SWITCH_JSY obj = new SWITCH_JSY();

            obj.DeviceId = deviceId;

            byte[] fBytesBuf = new byte[4] { 0, 0, 0, 0 };

            // 电压
            fBytesBuf[0] = data[15];
            fBytesBuf[1] = data[16];
            fBytesBuf[2] = 0;
            fBytesBuf[3] = 0;
            obj.Voltage = (double)BitConverter.ToInt32(fBytesBuf, 0) / 100;

            // 电流
            fBytesBuf[0] = data[17];
            fBytesBuf[1] = data[18];
            fBytesBuf[2] = 0;
            fBytesBuf[3] = 0;
            obj.Current = (double)BitConverter.ToInt32(fBytesBuf, 0) / 1000;

            // 有功功率
            fBytesBuf[0] = data[19];
            fBytesBuf[1] = data[20];
            fBytesBuf[2] = 0;
            fBytesBuf[3] = 0;
            obj.ActivePower = (double)BitConverter.ToInt32(fBytesBuf, 0) / 1000;

            // 无功功率
            fBytesBuf[0] = data[21];
            fBytesBuf[1] = data[22];
            fBytesBuf[2] = 0;
            fBytesBuf[3] = 0;
            obj.ReActivePower = (double)BitConverter.ToInt32(fBytesBuf, 0) / 1000;

            // 视在功率
            fBytesBuf[0] = data[23];
            fBytesBuf[1] = data[24];
            fBytesBuf[2] = 0;
            fBytesBuf[3] = 0;
            obj.ApparentPower = (double)BitConverter.ToInt32(fBytesBuf, 0) / 1000;

            // 功率因数
            fBytesBuf[0] = data[25];
            fBytesBuf[1] = data[26];
            fBytesBuf[2] = 0;
            fBytesBuf[3] = 0;
            obj.PowerFactor = (double)BitConverter.ToInt32(fBytesBuf, 0) / 1000;

            // 频率
            fBytesBuf[0] = data[27];
            fBytesBuf[1] = data[28];
            fBytesBuf[2] = 0;
            fBytesBuf[3] = 0;
            obj.Frequency = (double)BitConverter.ToInt32(fBytesBuf, 0) / 100;

            // 漏电流
            fBytesBuf[0] = data[29];
            fBytesBuf[1] = data[30];
            fBytesBuf[2] = 0;
            fBytesBuf[3] = 0;
            obj.LeakCurrent = (double)BitConverter.ToInt32(fBytesBuf, 0) / 10;

            // 温度
            fBytesBuf[0] = data[31];
            fBytesBuf[1] = data[32];
            fBytesBuf[2] = 0;
            fBytesBuf[3] = 0;
            obj.Temperature = (double)BitConverter.ToInt32(fBytesBuf, 0);

            // 湿度
            fBytesBuf[0] = data[33];
            fBytesBuf[1] = data[34];
            fBytesBuf[2] = 0;
            fBytesBuf[3] = 0;
            obj.Humidity = (double)BitConverter.ToInt32(fBytesBuf, 0);

            // 继电器状态
            obj.RelayStatus = data[35];

            // 报警状态
            obj.WarningStatus = data[36];

            // 当前电量
            fBytesBuf[0] = data[37];
            fBytesBuf[1] = data[38];
            fBytesBuf[2] = data[39];
            fBytesBuf[3] = data[40];
            obj.CurrentPower = (double)BitConverter.ToInt32(fBytesBuf, 0) / 100;

            // 购买电量
            fBytesBuf[0] = data[41];
            fBytesBuf[1] = data[42];
            fBytesBuf[2] = data[43];
            fBytesBuf[3] = data[44];
            obj.BoughtPower = (double)BitConverter.ToInt32(fBytesBuf, 0) / 100;

            return obj;
        }
    }
}
