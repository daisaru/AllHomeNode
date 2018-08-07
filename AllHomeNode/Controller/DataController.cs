using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Http;
using System.Reflection;

using AllHomeNode.Front;
using AllHomeNode.Repository;
using AllHomeNode.Auth;
using AllHomeNode.Help;

namespace AllHomeNode.Controller
{
    public class DataController : ApiController
    {
        private DataRepository repository = new DataRepository();

        public LogHelper Log { get; set; }

        #region // 获取一段时间内空气质量数据
        // POST /api/data/fetchairdata
        public GetAirQualityRspData FetchAirData([FromBody]GetAirQualityReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            GetAirQualityRspData ret = new GetAirQualityRspData();

            bool checkToken = ServiceToken.Intance().isTokenValid(item.Mobile, item.Token);
            if (checkToken == false)
            {
                LogHelper.WriteLog(LogLevel.Error, t, "Token Invalid");

                ret.Result = CommandUtil.RETURN.ERROR_TOKEN_INVALID;
                ret.AirQuality = null;
                return ret;
            }

            try
            {
                List<AirQualityData> data = repository.GetHistoryAirData(item.GatewayId, item.StartTime, item.EndTime).ToList();
                ret.Result = CommandUtil.RETURN.SUCCESS;
                ret.AirQuality = data;
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                ret.AirQuality = null;
                return ret;
            }

            return ret;
        }

        #endregion

        #region // 获取一段时间电量消耗数据
        // POST /api/data/fetchpowerconsumedata
        public GetMonthPowerConsumeRspData FetchPowerConsumeData([FromBody]GetMonthPowerConsumeReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            GetMonthPowerConsumeRspData ret = new GetMonthPowerConsumeRspData();

            bool checkToken = ServiceToken.Intance().isTokenValid(item.Mobile, item.Token);
           if (checkToken == false)
            {
                LogHelper.WriteLog(LogLevel.Error, t, "Token Invalid");

                ret.Result = CommandUtil.RETURN.ERROR_TOKEN_INVALID;
                ret.PowerConsume = null;
                return ret;
            }

            try
            {
                List<PowerConsumeData> datas = repository.GetHistoryPowerConsumeData(item.GatewayId, item.StartTime, item.EndTime, item.IsDetail).ToList();

                double dLight = 0.00;
                double dAir = 0.00;
                foreach(PowerConsumeData data in datas)
                {
                    dLight = dLight + double.Parse(data.Power_Light);
                    dAir = dAir + double.Parse(data.Power_Air);
                }

                ret.Result = CommandUtil.RETURN.SUCCESS;
                ret.Power_Light = dLight.ToString();
                ret.Power_Air = dAir.ToString();
                ret.Power_Total = (dLight + dAir).ToString();
                ret.PowerConsume = datas;
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                ret.PowerConsume = null;
                return ret;
            }

            return ret;
        }

        #endregion
    }
}
