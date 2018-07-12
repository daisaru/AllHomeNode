﻿using System;
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

        // 获取用户名下某网关的分享信息
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
                List<GatewayShareData> shares = repository.GetDeviceShareData(item.Mobile, item.GatewayId).ToList();
                ret.Result = CommandUtil.RETURN.SUCCESS;
                ret.Shares = shares;
            }
            catch (Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                ret.Shares = null;
                return ret;
            }

            return ret;
        }

        // 根据设备ID，更新指定设备的名称
        // POST api/gateway/updatedeviceinfo
        public UpdateDeviceInfoRspData UpdateRoomInfo([FromBody]UpdateDeviceInfoReqData item)
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

                ret.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                return ret;
            }

            return ret;
        }


        // 获取用户名下所有绑定网关设备
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

                ret.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                ret.Gateway = null;
                return ret;
            }

            return ret;
        }

        // 绑定设备及已绑设备信息更新(管理员)
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

            try
            {
                repository.BindDeviceWithUser(item.Mobile, item.GatewayId, item.GatewayName);
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
                repository.ShareGatewayWithFriend(item.Friend, item.GatewayId, item.Privilege, item.Time);
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

                ret.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                return ret;
            }
            
            return ret;
        }

        // 获取设备访问权限
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
                ret.GatewayToken = "";
                ret.GatewayTokenLife = "";
                ret.TimeStamp = DateTime.Now.ToString();
                return ret;
            }

            try
            {
                Token token = GatewayToken.Intance().GetandRefreshToken(item.Mobile, item.GatewayId);
                ret.Result = CommandUtil.RETURN.SUCCESS;
                ret.GatewayToken = token.TokenString;
                ret.GatewayTokenLife = token.TokenLife.ToString();
                ret.TimeStamp = token.StartTime.ToString();
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                ret.GatewayToken = "";
                ret.GatewayTokenLife = "";
                ret.TimeStamp = DateTime.Now.ToString();
                return ret;
            }

            return ret;
        }

        // 获取网关设备所有访问控制点
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

                ret.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                ret.Device = null;
                return ret;
            }

            return ret;
        }

        // 网关设备注册
        // POST api/gateway/registerdevice
        public GatewayRegisterRspData RegisterDevice(GatewayRegisterReqData item)
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
        // POST api/gateway/uploadcontrolpoints
        public GatewayUploadCtrlPointsRspData UploadControlPoints(GatewayUploadCtrlPointsReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            GatewayUploadCtrlPointsRspData rsp = new GatewayUploadCtrlPointsRspData();

            try
            {
                bool ret = repository.UploadCtrlPoints(item.GatewayId, item.Rooms);

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