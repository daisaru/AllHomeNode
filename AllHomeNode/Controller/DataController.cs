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

        // 获取一段时间内空气质量数据
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
                List<AirQualityData> data = repository.GetHistoryAirData(item.DeviceId, item.StartTime, item.EndTime).ToList();
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

        // 获取一段时间电量消耗数据
        // POST /api/data/fetchpowerconsumedata
        public GetPowerConsumeRspData FetchPowerConsumeData([FromBody]GetPowerConsumeReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            GetPowerConsumeRspData ret = new GetPowerConsumeRspData();

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
                List<PowerConsumeData> data = repository.GetHistoryPowerConsumeData(item.DeviceId, item.StartTime, item.EndTime, item.IsDetail).ToList();
                ret.Result = CommandUtil.RETURN.SUCCESS;
                ret.PowerConsume = data;
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
    }
}
