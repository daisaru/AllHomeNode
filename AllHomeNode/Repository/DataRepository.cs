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
using AllHomeNode.Service.MQTT.Device;

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

        private PowerConsumeData FillPowerConsumeData(PowerDataSummary data)
        {
            PowerConsumeData ret = new PowerConsumeData();
            ret.Power_Light = data.Light;
            ret.Power_Air = data.Air;
            ret.Power_Total = data.Total;
            ret.Date = data.SummaryTime.ToShortDateString();
            return ret;
        }

        public IEnumerable<PowerConsumeData> GetHistoryPowerConsumeData(string deviceId, DateTime startTime, DateTime endTime, bool bDetail)
        {
            List<PowerConsumeData> powerConsumeData = new List<PowerConsumeData>();
            PowerDataSummaryManager powerDataSummaryMgr = new PowerDataSummaryManager();
            List<PowerDataSummary> historyDatas = null;

            if (bDetail == true)
            {
                historyDatas = powerDataSummaryMgr.GetDayPowerConsumeSummary(deviceId, startTime, endTime).ToList();

                if(endTime.Date == DateTime.Now.Date)
                {
                    // 加上今天当前的数据
                    PowerDataSummary latestDataSummary = powerDataSummaryMgr.GetLatestPowerSummary(deviceId, startTime, endTime);

                    PowerDataManager powerDataMgr = new PowerDataManager();
                    List<PowerData> todayData = powerDataMgr.GetPowerConsume(deviceId, DateTime.Now.Date, DateTime.Now).ToList();
                    PowerDataSummary todayDataSummary = new PowerDataSummary();
                    todayDataSummary.DeviceId = deviceId;
                    todayDataSummary.Air = "0";
                    todayDataSummary.Light = "0";
                    todayDataSummary.Total = "0";
                    todayDataSummary.SummaryTime = DateTime.Now;
                    todayDataSummary.IsMonth = 0;
              
                    foreach(PowerData data in todayData)
                    {
                        POWERCONSUMERTYPE type = (POWERCONSUMERTYPE)Enum.Parse(typeof(POWERCONSUMERTYPE), data.PowerType, true);
                        {
                            switch(type)
                            {
                                case POWERCONSUMERTYPE.AIRCONTROL:
                                    {
                                        if(todayDataSummary.Air.Equals("0"))
                                        {
                                            double p = double.Parse(data.PowerConsume) - double.Parse(latestDataSummary.Air);
                                            todayDataSummary.Air = p.ToString();
                                        }
                                        break;
                                    }
                                case POWERCONSUMERTYPE.LIGHT:
                                    {
                                        if (todayDataSummary.Light.Equals("0"))
                                        {
                                            double p = double.Parse(data.PowerConsume) - double.Parse(latestDataSummary.Light);
                                            todayDataSummary.Light = p.ToString();
                                        }
                                        break;
                                    }
                                default:
                                    {
                                        break;
                                    }
                            }
                        }
                    }
                    todayDataSummary.Total = (double.Parse(todayDataSummary.Air) + double.Parse(todayDataSummary.Light)).ToString();
                    historyDatas.Add(todayDataSummary);
                }
            }
            else
            {
                DateTime monthStart = new DateTime(startTime.Year, startTime.Month, 1);
                DateTime monthEnd = new DateTime(endTime.Year, endTime.Month + 1, 1).AddDays(-1);
                historyDatas = powerDataSummaryMgr.GetMonthPowerConsumeSummary(deviceId, monthStart, monthEnd).ToList();

                DateTime now = DateTime.Now;
                if(monthEnd.Year == now.Year && monthEnd.Month == now.Month)
                {
                    // 加上本月的已有数据
                    PowerDataSummary latestMonthDataSummary = powerDataSummaryMgr.GetLatestMonthPowerSummary(deviceId, startTime, endTime);

                    PowerDataManager powerDataMgr = new PowerDataManager();
                    List<PowerData> monthData = powerDataMgr.GetPowerConsume(deviceId, monthStart, DateTime.Now).ToList();

                    PowerDataSummary monthDataSummary = new PowerDataSummary();
                    monthDataSummary.DeviceId = deviceId;
                    monthDataSummary.Air = "0";
                    monthDataSummary.Light = "0";
                    monthDataSummary.Total = "0";
                    monthDataSummary.SummaryTime = DateTime.Now;
                    monthDataSummary.IsMonth = 1;

                    foreach (PowerData data in monthData)
                    {
                        POWERCONSUMERTYPE type = (POWERCONSUMERTYPE)Enum.Parse(typeof(POWERCONSUMERTYPE), data.PowerType, true);
                        {
                            switch (type)
                            {
                                case POWERCONSUMERTYPE.AIRCONTROL:
                                    {
                                        if (monthDataSummary.Air.Equals("0"))
                                        {
                                            double p = double.Parse(data.PowerConsume) - double.Parse(latestMonthDataSummary.Air);
                                            monthDataSummary.Air = p.ToString();
                                        }
                                        break;
                                    }
                                case POWERCONSUMERTYPE.LIGHT:
                                    {
                                        if (monthDataSummary.Light.Equals("0"))
                                        {
                                            double p = double.Parse(data.PowerConsume) - double.Parse(latestMonthDataSummary.Light);
                                            monthDataSummary.Light = p.ToString();
                                        }
                                        break;
                                    }
                                default:
                                    {
                                        break;
                                    }
                            }
                        }
                    }
                    monthDataSummary.Total = (double.Parse(monthDataSummary.Air) + double.Parse(monthDataSummary.Light)).ToString();
                    historyDatas.Add(monthDataSummary);
                }

                //// 统计不同类别分月总用电量
                //Hashtable powerStatic = new Hashtable();
                //foreach (PowerData data in datas)
                //{
                //    POWERCONSUMERTYPE type = (POWERCONSUMERTYPE)Enum.Parse(typeof(POWERCONSUMERTYPE), data.PowerType, true);

                //    string key = data.TimeStamp.Year + "-" + data.TimeStamp.Month + " " + type;
                //    if (powerStatic.ContainsKey(key))
                //    {
                //        float value = (float)powerStatic[key];
                //        value += float.Parse(data.PowerConsume);
                //        powerStatic.Remove(key);
                //        powerStatic.Add(key, value);
                //    }
                //    else
                //    {
                //        powerStatic.Add(key, float.Parse(data.PowerConsume));
                //    }
                //}

                //foreach (string key in powerStatic.Keys)
                //{
                //    string[] tmp = key.Split(new char[] { ' ' });
                //    PowerConsumeData data = new PowerConsumeData();
                //    data.TimeStamp = tmp[0];
                //    data.PowerType = tmp[1];
                //    data.PowerConsume = powerStatic[key].ToString();
                //    powerConsumeData.Add(data);
                //}
            }

            foreach (PowerDataSummary data in historyDatas)
            {
                PowerConsumeData tmp = FillPowerConsumeData(data);
                powerConsumeData.Add(tmp);
            }

            return powerConsumeData;
        }

        public bool AddPowerData(SWITCH_JSY data, string code)
        {
            if (data == null)
            {
                throw new ArgumentNullException("AddPowerData");
            }

            try
            {
                PowerData item = new PowerData();
                item.DeviceId = data.DeviceId;
                item.CPCode = code;
                item.PowerConsume = data.CurrentPower.ToString();
                item.PowerType = data.ConsumerType.ToString();
                item.TimeStamp = DateTime.Now;
                PowerDataManager powerDataMgr = new PowerDataManager();
                powerDataMgr.Add(item);
            }
            catch (Exception exp)
            {
                Console.WriteLine("ERROR:" + exp.Message);
                return false;
            }

            return true;
        }

        public bool AddAirData(VENT_EAWADA data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("AddAirData");
            }

            try
            {
                #region 填充AirData
                AirData airData = new AirData();
                airData.DeviceId = data.DeviceId;
                airData.ONOFF = data._ONOFF.ToString();
                airData.FAN_SPEED = data._FAN_SPD.ToString();           // 0:停止 1:低速 2:中速 3:高速
                airData.CIRCLE_MODE = data._CIRCLE_MODE.ToString();       // 0:内循环 1:外循环
                airData.AUTO_MODE = data._AUTO_MODE.ToString();         // 0:手动 1:自动
                airData.INNER_PM25 = data._INNER_PM25.ToString();        // 只读
                airData.INNER_CO2 = data._INNER_CO2.ToString();         // 只读
                airData.INNER_TEMP = data._INNER_TEMP.ToString();        // 只读
                airData.INNER_HUMI = data._INNER_HUMI.ToString();        // 只读
                airData.FANOUT_PM25 = data._FANOUT_PM25.ToString();       // 只读
                airData.FANOUT_TEMP = data._FANOUT_TEMP.ToString();       // 只读
                airData.FANOUT_HUMI = data._FANOUT_HUMI.ToString();       // 只读
                airData.LOWSPEED_INNERCIRCLETIME_L = data._LOWSPD_INNERCIRCLETIME_L.ToString();
                airData.LOWSPEED_INNERCIRCLETIME_H = data._LOWSPD_INNERCIRCLETIME_H.ToString();
                airData.MIDSPEED_INNERCIRCLETIME_L = data._MIDSPD_INNERCIRCLETIME_L.ToString();
                airData.MIDSPEED_INNERCIRCLETIME_H = data._MIDSPD_INNERCIRCLETIME_H.ToString();
                airData.HISPEED_INNERCIRCLETIME_L = data._HISPD_INNERCIRCLETIME_L.ToString();
                airData.HISPEED_INNERCIRCLETIME_H = data._HISPD_INNERCIRCLETIME_H.ToString();
                airData.LOWSPEED_OUTERCIRCLETIME_L = data._LOWSPD_OUTERCIRCLETIME_L.ToString();
                airData.LOWSPEED_OUTERCIRCLETIME_H = data._LOWSPD_OUTERCIRCLETIME_H.ToString();
                airData.MIDSPEED_OUTERCIRCLETIME_L = data._MIDSPD_OUTERCIRCLETIME_L.ToString();
                airData.MIDSPEED_OUTERCIRCLETIME_H = data._MIDSPD_OUTERCIRCLETIME_H.ToString();
                airData.HISPEED_OUTERCIRCLETIME_L = data._HISPD_OUTERCIRCLETIME_L.ToString();
                airData.HISPEED_OUTERCIRCLETIME_H = data._HISPD_OUTERCIRCLETIME_H.ToString();
                airData.TOTAL_TIME_L = data._TOTAL_TIME_L.ToString();
                airData.TOTAL_TIME_H = data._TOTAL_TIME_H.ToString();
                airData.ERROR_CODE = data._ERR_CODE.ToString();
                airData.FILTER_DUSTWEIGHT_L = data._FILTER_DUSTWT_L.ToString();
                airData.FILTER_DUSTWEIGHT_H = data._FILTER_DUSTWT_H.ToString();
                airData.FILTER_DUSTWARNINGWEIGHT_L = data._FILTER_DUSTWARNWT_L.ToString();
                airData.FILTER_DUSTWARNINGWEIGHT_H = data._FILTER_DUSTWARNWT_H.ToString();
                airData.CONDITION_AUTOMODE_CIRCLEMODE_PM25 = data._CONDITION_AUTO_CIRCLEMODE_PM25.ToString();
                airData.CONDITION_AUTOMODE_CIRCLEMODE_CO2 = data._CONDITION_AUTO_CIRCLEMODE_CO2.ToString();
                airData.CONDITION_AUTOMODE_FANSPEED_PM25 = data._CONDITION_AUTO_FANSPEED_PM25.ToString();
                airData.CONDITION_AUTOMODE_FANSPEED_CO2 = data._CONDITION_AUTO_FANSPEED_CO2.ToString();
                airData.DUSTWEIGHT_NOW_L = data._DUSTWT_NOW_L.ToString();
                airData.DUSTWEIGHT_NOW_H = data._DUSTWT_NOW_H.ToString();
                airData.TOTALWEIGHT_L_0 = data._TOTALWT_L_0.ToString();
                airData.TOTALWEIGHT_L_1 = data._TOTALWT_L_1.ToString();
                airData.TOTALWEIGHT_H_0 = data._TOTALWT_H_0.ToString();
                airData.TOTALWEIGHT_H_1 = data._TOTALWT_H_1.ToString();
                #endregion
                airData.TimeStamp = DateTime.Now;

                AirDataManager airDataMgr = new AirDataManager();
                airDataMgr.Add(airData);
            }
            catch (Exception exp)
            {
                Console.WriteLine("ERROR:" + exp.Message);
                return false;
            }

            return true;
        }
    }
}
