using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;

using AllHomeNode.Front;
using AllHomeNode.Database.Model;
using AllHomeNode.Database.Manager;
using static AllHomeNode.Service.MQTT.Enums;

namespace AllHomeNode.Repository
{
    public class DataRepository
    {
        public DataRepository()
        {
        }

        private AirQualityData FillAirDataObject(AirData data)
        {
            AirQualityData ret = new AirQualityData();
            ret.FANOUT_HUMI = data.FANOUT_HUMI;
            ret.FANOUT_PM25 = data.FANOUT_PM25;
            ret.FANOUT_TEMP = data.FANOUT_TEMP;
            ret.INNER_CO2 = data.INNER_CO2;
            ret.INNER_HUMI = data.INNER_HUMI;
            ret.INNER_PM25 = data.INNER_PM25;
            ret.INNER_TEMP = data.INNER_TEMP;
            ret.TimeStamp = data.TimeStamp.ToString();
            return ret;
        }

        public IEnumerable<AirQualityData> GetHistoryAirData(string deviceId, DateTime startTime, DateTime endTime)
        {
            List<AirQualityData> airData = new List<AirQualityData>();
            AirDataManager airDataMgr = new AirDataManager();
            List<AirData> datas = airDataMgr.GetHistoryAirQuality(deviceId, startTime, endTime).ToList();
            foreach (AirData data in datas)
            {
                AirQualityData tmp = FillAirDataObject(data);
                airData.Add(tmp);
            }
            return airData;
        }

        private PowerConsumeData FillPowerConsumeData(PowerData data)
        {
            PowerConsumeData ret = new PowerConsumeData();
            ret.PowerConsume = data.PowerConsume;
            ret.PowerType = data.PowerType;
            ret.TimeStamp = data.TimeStamp.ToString();
            return ret;
        }

        public IEnumerable<PowerConsumeData> GetHistoryPowerConsumeData(string deviceId, DateTime startTime, DateTime endTime, bool bDetail)
        {
            List<PowerConsumeData> powerConsumeData = new List<PowerConsumeData>();
            PowerDataManager powerDataMgr = new PowerDataManager();
            List<PowerData> datas = null;

            if(bDetail == true)
            {
                datas = powerDataMgr.GetHistoryPowerConsume(deviceId, startTime, endTime).ToList();
                foreach (PowerData data in datas)
                {
                    PowerConsumeData tmp = FillPowerConsumeData(data);
                    powerConsumeData.Add(tmp);
                }
            }
            else
            {
                DateTime monthStart = new DateTime(startTime.Year, startTime.Month, 1);
                DateTime monthEnd = new DateTime(endTime.Year, endTime.Month + 1, 1).AddDays(-1);
                datas = powerDataMgr.GetHistoryPowerConsume(deviceId, monthStart, monthEnd).ToList();

                // 统计不同类别分月总用电量
                Hashtable powerStatic = new Hashtable();
                foreach(PowerData data in datas)
                {
                    POWERCONSUMERTYPE type = (POWERCONSUMERTYPE)Enum.Parse(typeof(POWERCONSUMERTYPE), data.PowerType, true);

                    string key = data.TimeStamp.Year + "-" + data.TimeStamp.Month + " " + (int)type;
                    if(powerStatic.ContainsKey(key))
                    {
                        float value = (float)powerStatic[key];
                        value += float.Parse(data.PowerConsume);
                        powerStatic.Remove(key);
                        powerStatic.Add(key, value);
                    }
                    else
                    {
                        powerStatic.Add(key, float.Parse(data.PowerConsume));
                    }                             
                }

                // 
                foreach(string key in powerStatic.Keys)
                {
                    string[] tmp = key.Split(new char[] { ' ' });
                    PowerConsumeData data = new PowerConsumeData();
                    data.TimeStamp = tmp[0];
                    data.PowerType = tmp[1];
                    data.PowerConsume = powerStatic[key].ToString();
                    powerConsumeData.Add(data);
                }
            }

            return powerConsumeData;
        }
    }
}
