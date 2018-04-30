using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Reflection;

using AllHomeNode.Front;
using AllHomeNode.Front.controlpoints;
using AllHomeNode.Repository;
using AllHomeNode.Auth;
using AllHomeNode.Help;


namespace AllHomeNode.controller
{
    public class DeviceController : ApiController
    {
        private DeviceRepository repository = new DeviceRepository();

        // 获取用户名下所有绑定网关设备
        // POST api/device/fetchalldevices
        public GetAllDevicesRspData FetchAllDevices([FromBody]GetAllDevicesReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            GetAllDevicesRspData ret = new GetAllDevicesRspData();

            bool checkToken = ServiceToken.Intance().isTokenValid(item.Mobile, item.Token);
            if (checkToken == false)
            {
                LogHelper.WriteLog(LogLevel.Error, t, "Token Invalid");

                ret.Result = CommandUtil.RETURN.ERROR_TOKEN_INVALID;
                ret.Devices = null;
                return ret;
            }

            try
            {
                List<UserDeviceData> devices = repository.GetAllBindDevices(item.Mobile).ToList();
                ret.Result = CommandUtil.RETURN.SUCCESS;
                ret.Devices = devices;
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                ret.Devices = null;
                return ret;
            }

            return ret;
        }

        // 绑定设备及已绑设备信息更新(管理员)
        // POST api/device/bind
        public ReturnResult Bind([FromBody]BindDeviceReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            ReturnResult ret = new ReturnResult();

            bool checkToken = ServiceToken.Intance().isTokenValid(item.Mobile, item.Token);
            if (checkToken == false)
            {
                LogHelper.WriteLog(LogLevel.Error, t, "Token Invalid");

                ret.Result = CommandUtil.RETURN.ERROR_TOKEN_INVALID;
                return ret;
            }

            try
            {
                repository.BindDeviceWithUser(item.Mobile, item.DeviceId, item.DeviceName);
                ret.Result = CommandUtil.RETURN.SUCCESS;
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                return ret;
            }

            return ret;
        }

        // 分享设备及变更
        // POST api/device/share
        public ReturnResult Share([FromBody]ShareDeviceReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            ReturnResult ret = new ReturnResult();

            bool checkToken = ServiceToken.Intance().isTokenValid(item.Mobile, item.Token);
            if (checkToken == false)
            {
                LogHelper.WriteLog(LogLevel.Error, t, "Token Invalid");

                ret.Result = CommandUtil.RETURN.ERROR_TOKEN_INVALID;
                return ret;
            }

            try
            {
                repository.ShareDeviceWithFriend(item.Friend, item.DeviceId, item.Privilege);
                ret.Result = CommandUtil.RETURN.SUCCESS;
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                return ret;
            }
              
            return ret;
        }

        // 分享取消
        // POST api/device/sharerevoke
        public ReturnResult ShareRevoke([FromBody]ShareDeviceReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            ReturnResult ret = new ReturnResult();

            bool checkToken = ServiceToken.Intance().isTokenValid(item.Mobile, item.Token);
            if (checkToken == false)
            {
                LogHelper.WriteLog(LogLevel.Error, t, "Token Invalid");

                ret.Result = CommandUtil.RETURN.ERROR_TOKEN_INVALID;
                return ret;
            }

            try
            {
                repository.RevokeShareWithFriend(item.Friend, item.DeviceId);
            }
            catch (Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                return ret;
            }
            
            return ret;
        }

        // 获取设备访问权限
        // POST api/device/fetchaccesstoken
        public GetDeviceTokenRspData FetchAccessToken([FromBody]GetDeviceTokenReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            GetDeviceTokenRspData ret = new GetDeviceTokenRspData();

            bool checkToken = ServiceToken.Intance().isTokenValid(item.Mobile, item.Token);
            if (checkToken == false)
            {
                LogHelper.WriteLog(LogLevel.Error, t, "Token Invalid");

                ret.Result = CommandUtil.RETURN.ERROR_TOKEN_INVALID;
                ret.DeviceToken = "";
                ret.DeviceTokenLife = "";
                ret.TimeStamp = DateTime.Now.ToString();
                return ret;
            }

            try
            {
                Token token = DeviceToken.Intance().GetandRefreshToken(item.Mobile, item.DeviceId);
                ret.Result = CommandUtil.RETURN.SUCCESS;
                ret.DeviceToken = token.TokenString;
                ret.DeviceTokenLife = token.TokenLife.ToString();
                ret.TimeStamp = token.StartTime.ToString();
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                ret.DeviceToken = "";
                ret.DeviceTokenLife = "";
                ret.TimeStamp = DateTime.Now.ToString();
                return ret;
            }

            return ret;
        }

        // 获取网关设备所有访问控制点
        // POST api/device/fetchcontrolpoints
        public GetControlPointsRspData FetchControlPoints([FromBody]GetControlPointsReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            GetControlPointsRspData ret = new GetControlPointsRspData();

            bool checkToken = ServiceToken.Intance().isTokenValid(item.Mobile, item.Token);
            if (checkToken == false)
            {
                LogHelper.WriteLog(LogLevel.Error, t, "Token Invalid");

                ret.Result = CommandUtil.RETURN.ERROR_TOKEN_INVALID;
                ret.Rooms = null;
                return ret;
            }

            try
            {
                ret.Rooms = repository.GetAllControlPoints(item.DeviceId).ToList();
                ret.Result = CommandUtil.RETURN.SUCCESS;
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                ret.Rooms = null;
                return ret;
            }

            return ret;
        }

        // 网关设备注册
        // POST api/device/registerdevice
        public GatewayRegisterRspData RegisterDevice(GatewayRegisterReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            GatewayRegisterRspData rsp = new GatewayRegisterRspData();

            try
            {
                bool ret = repository.RegisterDevice(item.DeviceId, item.DeviceName);

                if (ret == true)
                {
                    rsp.Result = CommandUtil.RETURN.SUCCESS;
                }
                else
                {
                    rsp.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                }

                rsp.TimeStamp = DateTime.Now.ToString();
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                rsp.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                rsp.TimeStamp = DateTime.Now.ToString();
                return rsp;
            }

            return rsp;
        }

        // 网关上报房间及控制点信息
        // POST api/device/uploadcontrolpoints
        public GatewayUploadCtrlPointsRspData UploadControlPoints(GatewayUploadCtrlPointsReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            GatewayUploadCtrlPointsRspData rsp = new GatewayUploadCtrlPointsRspData();

            try
            {
                bool ret = repository.UploadCtrlPoints(item.DeviceId, item.Rooms);

                if (ret == true)
                {
                    rsp.Result = CommandUtil.RETURN.SUCCESS;
                }
                else
                {
                    rsp.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                }
                rsp.TimeStamp = DateTime.Now.ToString();
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                rsp.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                rsp.TimeStamp = DateTime.Now.ToString();
                return rsp;
            }

            return rsp;
        }
    }
}
