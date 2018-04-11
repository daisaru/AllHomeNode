using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using AllHomeNode.Front;
using AllHomeNode.Database.Model;
using AllHomeNode.Database.Manager;

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
            ret.TimeStamp = data.TimeStamp.ToString();
            return ret;
        }

        public IEnumerable<PowerConsumeData> GetHistoryPowerConsumeData(string deviceId, DateTime startTime, DateTime endTime)
        {
            List<PowerConsumeData> powerConsumeData = new List<PowerConsumeData>();
            PowerDataManager powerDataMgr = new PowerDataManager();
            List<PowerData> datas = powerDataMgr.GetHistoryPowerConsume(deviceId, startTime, endTime).ToList();
            foreach (PowerData data in datas)
            {
                PowerConsumeData tmp = FillPowerConsumeData(data);
                powerConsumeData.Add(tmp);
            }
            return powerConsumeData;
        }
    }
}
