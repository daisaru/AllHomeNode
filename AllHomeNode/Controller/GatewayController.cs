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
    public class GatewayController : ApiController
    {
        private GatewayRepository repository = new GatewayRepository();

        #region// 获取用户名下某网关的分享信息
        // POST api/gateway/fetchshareinfo
        public GetGatewayShareInfoRspData FetchShareInfo([FromBody]GetGatewayShareInfoReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            GetGatewayShareInfoRspData ret = new GetGatewayShareInfoRspData();

            bool checkToken = ServiceToken.Intance().isTokenValid(item.Mobile, item.Token);
            if (checkToken == false)
            {
                LogHelper.WriteLog(LogLevel.Error, t, "Token Invalid");

                ret.Result = CommandUtil.RETURN.ERROR_TOKEN_INVALID;
                ret.Shares = null;
                return ret;
            }

            try
            {
                List<GatewayShareData> shares = repository.GetGatewayShareData(item.Mobile, item.GatewayId).ToList();
                ret.Result = CommandUtil.RETURN.SUCCESS;
                ret.Shares = shares;
            }
            catch (Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_DATABASE_ERROR;
                ret.Shares = null;
                return ret;
            }

            return ret;
        }

        #endregion

        #region// 根据网关ID，删除其所属的所有设备及其控制点信息
        // POST api/gateway/uninstallalldevice
        public DeleteAllDeviceRspData UninstallAllDevice([FromBody]DeleteAllDeviceReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            DeleteAllDeviceRspData ret = new DeleteAllDeviceRspData();
            ret.Result = CommandUtil.RETURN.ERROR_UNKNOW;

            bool checkToken = ServiceToken.Intance().isTokenValid(item.Mobile, item.Token);
            if (checkToken == false)
            {
                LogHelper.WriteLog(LogLevel.Error, t, "Token Invalid");

                ret.Result = CommandUtil.RETURN.ERROR_TOKEN_INVALID;
                return ret;
            }

            try
            {
                // 检查权限
                bool checkRight = repository.CheckRight(item.Mobile, item.GatewayId);
                if (checkRight == false)
                {
                    ret.Result = CommandUtil.RETURN.ERROR_NO_PRIVILEGE;
                    return ret;
                }

                // 删除所有设备
                bool uninstallRet = repository.DeleteAllDeviceFromGateway(item.GatewayId);
                if (uninstallRet == false)
                {
                    ret.Result = CommandUtil.RETURN.ERROR_DATABASE_ERROR;
                    return ret;
                }
            }
            catch (Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_SERVICE_UNAVAILABLE;
                return ret;
            }

            ret.Result = CommandUtil.RETURN.SUCCESS;
            return ret;
        }
        #endregion

        #region// 根据设备ID，从其所隶属的网关中删除，同时删除所有控制点信息
        // POST api/gateway/uninstalldevice
        public DeleteDeviceRspData UninstallDevice([FromBody]DeleteDeviceReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            DeleteDeviceRspData ret = new DeleteDeviceRspData();
            ret.Result = CommandUtil.RETURN.ERROR_UNKNOW;

            bool checkToken = ServiceToken.Intance().isTokenValid(item.Mobile, item.Token);
            if (checkToken == false)
            {
                LogHelper.WriteLog(LogLevel.Error, t, "Token Invalid");

                ret.Result = CommandUtil.RETURN.ERROR_TOKEN_INVALID;
                return ret;
            }

            try
            {
                // 检查权限
                bool checkRight = repository.CheckRight(item.Mobile, item.GatewayId);
                if(checkRight == false)
                {
                    ret.Result = CommandUtil.RETURN.ERROR_NO_PRIVILEGE;
                    return ret;
                }

                // 删除设备信息
                bool deleteDevice = repository.DeleteDeviceFromGateway(item.DeviceId);
                if(deleteDevice == false)
                {
                    ret.Result = CommandUtil.RETURN.ERROR_DATABASE_ERROR;
                    return ret;
                }
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_SERVICE_UNAVAILABLE;
                return ret;
            }

            ret.Result = CommandUtil.RETURN.SUCCESS;
            return ret;
        }
        #endregion

        #region// 根据设备ID，更新指定设备的名称
        // POST api/gateway/updatedeviceinfo
        public UpdateDeviceInfoRspData UpdateDeviceInfo([FromBody]UpdateDeviceInfoReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            UpdateDeviceInfoRspData ret = new UpdateDeviceInfoRspData();

            bool checkToken = ServiceToken.Intance().isTokenValid(item.Mobile, item.Token);
            if (checkToken == false)
            {
                LogHelper.WriteLog(LogLevel.Error, t, "Token Invalid");

                ret.Result = CommandUtil.RETURN.ERROR_TOKEN_INVALID;
                return ret;
            }

            try
            {
                // update
                repository.UpdateDeviceInfoById(item.DeviceId, item.DeviceName);
                ret.Result = CommandUtil.RETURN.SUCCESS;
            }
            catch (Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_DATABASE_ERROR;
                return ret;
            }

            return ret;
        }
        #endregion

        #region// 获取用户名下所有绑定网关设备
        // POST api/gateway/fetchallgateway
        public GetAllGatewayRspData FetchAllGateway([FromBody]GetAllGatewayReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            GetAllGatewayRspData ret = new GetAllGatewayRspData();

            bool checkToken = ServiceToken.Intance().isTokenValid(item.Mobile, item.Token);
            if (checkToken == false)
            {
                LogHelper.WriteLog(LogLevel.Error, t, "Token Invalid");

                ret.Result = CommandUtil.RETURN.ERROR_TOKEN_INVALID;
                ret.Gateway = null;
                return ret;
            }

            try
            {
                List<UserGatewayData> gateway = repository.GetAllBindGateway(item.Mobile).ToList();
                ret.Result = CommandUtil.RETURN.SUCCESS;
                ret.Gateway = gateway;
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_DATABASE_ERROR;
                ret.Gateway = null;
                return ret;
            }

            return ret;
        }
        #endregion

        #region// 绑定设备及已绑设备信息更新(管理员)
        // POST api/gateway/bind
        public ReturnResult Bind([FromBody]BindGatewayReqData item)
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

            //TODO:如果已经绑定了，则不允许再次绑定，一个设备只允许一个管理员账户，其他用户权限由管理员分享。

            try
            {
                repository.BindGatewayWithUser(item.Mobile, item.GatewayId, item.GatewayName);
                ret.Result = CommandUtil.RETURN.SUCCESS;
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_DATABASE_ERROR;
                return ret;
            }

            return ret;
        }
        #endregion

        #region// 分享设备及变更
        // POST api/gateway/share
        public ReturnResult Share([FromBody]ShareGatewayReqData item)
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
                //TODO:检查朋友的手机号是否已经注册成为系统账户！
                repository.ShareGatewayWithFriend(item.Friend, item.GatewayId, item.Privilege, item.Time);
                ret.Result = CommandUtil.RETURN.SUCCESS;
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_DATABASE_ERROR;
                return ret;
            }
              
            return ret;
        }
        #endregion

        #region// 分享取消
        // POST api/gateway/sharerevoke
        public ReturnResult ShareRevoke([FromBody]ShareGatewayReqData item)
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
                repository.RevokeShareWithFriend(item.Friend, item.GatewayId);
            }
            catch (Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_DATABASE_ERROR;
                return ret;
            }
            
            return ret;
        }
        #endregion

        #region// 获取设备访问权限
        // POST api/gateway/fetchaccesstoken
        public GetGatewayTokenRspData FetchAccessToken([FromBody]GetGatewayTokenReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            GetGatewayTokenRspData ret = new GetGatewayTokenRspData();

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
                Token token = GatewayToken.Intance().GetandRefreshToken(item.Mobile, item.GatewayId);
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
        #endregion

        #region// 获取网关设备所有访问控制点
        // POST api/gateway/fetchcontrolpoints
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
                ret.Device = null;
                return ret;
            }

            try
            {
                ret.Device = repository.GetAllControlPoints(item.GatewayId).ToList();
                ret.Result = CommandUtil.RETURN.SUCCESS;
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_DATABASE_ERROR;
                ret.Device = null;
                return ret;
            }

            return ret;
        }
        #endregion

        #region// 添加设备到指定网关
        // POST api/gateway/adddevice
        public AddDeviceRspData AddDevice([FromBody]AddDeviceReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            AddDeviceRspData ret = new AddDeviceRspData();
            ret.Result = CommandUtil.RETURN.ERROR_UNKNOW;

            try
            {
                bool checkToken = ServiceToken.Intance().isTokenValid(item.Mobile, item.Token);
                if (checkToken == false)
                {
                    LogHelper.WriteLog(LogLevel.Error, t, "Token Invalid");

                    ret.Result = CommandUtil.RETURN.ERROR_TOKEN_INVALID;
                    return ret;
                }

                // 检查权限
                bool checkRight = repository.CheckRight(item.Mobile, item.GatewayId);
                if (checkRight == false)
                {
                    ret.Result = CommandUtil.RETURN.ERROR_NO_PRIVILEGE;
                    return ret;
                }

                bool addRet = repository.AddDeviceToGateway(item.GatewayId, item.Device);   
                if(addRet == false)
                {
                    ret.Result = CommandUtil.RETURN.ERROR_DATABASE_ERROR;
                    return ret;
                }
            }
            catch (Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_SERVICE_UNAVAILABLE;
                return ret;
            }

            ret.Result = CommandUtil.RETURN.SUCCESS;
            return ret;
        }
        #endregion

        #region// 网关设备注册
        // POST api/gateway/registerdevice
        public GatewayRegisterRspData RegisterDevice([FromBody]GatewayRegisterReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            GatewayRegisterRspData rsp = new GatewayRegisterRspData();

            try
            {
                bool ret = repository.RegisterGateway(item.GatewayId, item.GatewayName);

                if (ret == true)
                {
                    rsp.Result = CommandUtil.RETURN.SUCCESS;
                }
                else
                {
                    rsp.Result = CommandUtil.RETURN.ERROR_DATABASE_ERROR;
                }

                rsp.TimeStamp = DateTime.Now.ToString();
            }
            catch (Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                rsp.Result = CommandUtil.RETURN.ERROR_SERVICE_UNAVAILABLE;
                rsp.TimeStamp = DateTime.Now.ToString();
                return rsp;
            }

            return rsp;
        }
        #endregion

        #region// 网关上报房间及控制点信息
        // POST api/gateway/uploadcontrolpoints
        public GatewayUploadCtrlPointsRspData UploadControlPoints([FromBody]GatewayUploadCtrlPointsReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);
            
            GatewayUploadCtrlPointsRspData rsp = new GatewayUploadCtrlPointsRspData();

            try
            {
                bool ret = repository.UploadCtrlPoints(item.GatewayId, item.Device);

                if (ret == true)
                {
                    rsp.Result = CommandUtil.RETURN.SUCCESS;
                }
                else
                {
                    rsp.Result = CommandUtil.RETURN.ERROR_DATABASE_ERROR;
                }
                rsp.TimeStamp = DateTime.Now.ToString();
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                rsp.Result = CommandUtil.RETURN.ERROR_SERVICE_UNAVAILABLE;
                rsp.TimeStamp = DateTime.Now.ToString();
                return rsp;
            }

            return rsp;
        }
        #endregion
    }
}
