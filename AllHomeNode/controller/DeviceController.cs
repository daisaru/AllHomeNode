﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

using AllHomeNode.model;
using AllHomeNode.model.controlpoints;
using AllHomeNode.Repository;
using AllHomeNode.Auth;

namespace AllHomeNode.controller
{
    public class DeviceController : ApiController
    {
        private DeviceRepository repository = new DeviceRepository();

        // 获取用户名下所有绑定网关设备
        // POST api/device/fetchalldevices
        public GetAllDevicesRspData FetchAllDevices([FromBody]GetAllDevicesReqData item)
        {
            List<UserDeviceData> devices = repository.GetAllBindDevices(item.Mobile).ToList();
            GetAllDevicesRspData ret = new GetAllDevicesRspData();
            ret.Result = CommandUtil.RETURN.SUCCESS;
            ret.Devices = devices;
            return ret;
        }

        // 绑定设备及已绑设备信息更新(管理员)
        // POST api/device/bind
        public ReturnResult Bind([FromBody]BindDeviceReqData item)
        {
            repository.BindDeviceWithUser(item.Mobile, item.DeviceId, item.DeviceName);
            ReturnResult ret = new ReturnResult();
            ret.Result = CommandUtil.RETURN.SUCCESS;
            return ret;
        }

        // 分享设备及变更
        // POST api/device/share
        public ReturnResult Share([FromBody]ShareDeviceReqData item)
        {
            repository.ShareDeviceWithFriend(item.Friend, item.DeviceId, item.Privilege);
            ReturnResult ret = new ReturnResult();
            ret.Result = CommandUtil.RETURN.SUCCESS;
            return ret;
        }

        // 分享取消
        // POST api/device/sharerevoke
        public ReturnResult ShareRevoke([FromBody]ShareDeviceReqData item)
        {
            repository.RevokeShareWithFriend(item.Friend, item.DeviceId);
            ReturnResult ret = new ReturnResult();
            ret.Result = CommandUtil.RETURN.SUCCESS;
            return ret;
        }

        // 获取设备访问权限
        // POST api/device/fetchaccesstoken
        public GetDeviceTokenRspData FetchAccessToken([FromBody]GetDeviceTokenReqData item)
        {
            GetDeviceTokenRspData ret = new GetDeviceTokenRspData();
            Token token = DeviceToken.Intance().GetandRefreshToken(item.Mobile, item.DeviceId);
            ret.Result = CommandUtil.RETURN.SUCCESS;
            ret.DeviceToken = token.TokenString;
            ret.DeviceTokenLife = token.TokenLife.ToString();
            ret.TimeStamp = token.StartTime.ToString();
            return ret;
        }

        // 获取网关设备所有访问控制点
        // POST api/device/fetchcontrolpoints
        public GetControlPointsRspData FetchControlPoints([FromBody]GetControlPointsReqData item)
        {
            GetControlPointsRspData ret = new GetControlPointsRspData();
            ret.Rooms = repository.GetAllControlPoints(item.DeviceId).ToList();
            ret.Result = CommandUtil.RETURN.SUCCESS;
            return ret;
        }
    }
}
