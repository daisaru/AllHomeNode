using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

using AllHomeNode.model;
using AllHomeNode.model.controlpoints;
using AllHomeNode.Repository;

namespace AllHomeNode.controller
{
    public class DeviceController : ApiController
    {
        private readonly IDeviceRepository repository = new DeviceRepository();

        // 获取用户名下所有绑定网关设备
        // POST api/device/fetchalldevices
        public GetAllDevicesRspData FetchAllDevices()
        {
            List<UserDeviceData> devices = new List<UserDeviceData>();
            for (int i = 0; i < 5; i++)
            {
                UserDeviceData data = new UserDeviceData();
                data.DeviceId = "id=" + i;
                data.DeviceName = "name=" + i;
                data.Privilege = CommandUtil.PRIVILEGE.CONTROL;
                devices.Add(data);                
            }

            GetAllDevicesRspData ret = new GetAllDevicesRspData();
            ret.Result = CommandUtil.RETURN.SUCCESS;
            ret.Devices = devices;
            return ret;
        }

        //// GET /api/device/?DeviceId=deviceId
        //public IEnumerable<UserData> GetDevicesById(string deviceId)
        //{
        //    return repository
        //        .GetAll()
        //        .Where(r => string.Equals(r.Mobile, mobile))
        //        .Select(r => r);
        //}

        // 绑定设备
        // POST api/device/bind
        public ReturnResult Bind([FromBody]BindDeviceReqData item)
        {
            ReturnResult ret = new ReturnResult();
            ret.Result = CommandUtil.RETURN.SUCCESS;
            return ret;
        }

        // 分享设备及变更
        // POST api/device/share
        public ReturnResult Share([FromBody]ShareDeviceReqData item)
        {
            ReturnResult ret = new ReturnResult();
            ret.Result = CommandUtil.RETURN.SUCCESS;
            return ret;
        }

        // 分享取消
        // POST api/device/sharerevoke
        public ReturnResult ShareRevoke([FromBody]ShareDeviceReqData item)
        {
            ReturnResult ret = new ReturnResult();
            ret.Result = CommandUtil.RETURN.SUCCESS;
            return ret;
        }

        // 获取设备访问权限
        // POST api/device/fetchaccesstoken
        public GetDeviceTokenRspData FetchAccessToken([FromBody]GetDeviceTokenReqData item)
        {
            GetDeviceTokenRspData ret = new GetDeviceTokenRspData();
            return ret;
        }

        // 获取网关设备所有访问控制点
        // POST api/device/fetchcontrolpoints
        public GetControlPointsRspData FetchControlPoints([FromBody]GetControlPointsReqData item)
        {
            GetControlPointsRspData ret = new GetControlPointsRspData();
            ret.Result = CommandUtil.RETURN.SUCCESS;
            for(int i = 0; i < 3; i++)
            {
                RoomData room = new RoomData();
                room.Name = "房间" + i;
                { 
                    ControlPointData aircon = new ControlPointData();
                    aircon.Name = "空调" + i;
                    aircon.Code = Guid.NewGuid().ToString("N");
                    aircon.Brand = "DAIKIN";
                    aircon.Model = "DK100001";
                    aircon.Type = CommandUtil.CONTROLPOINT_TYPE.AIRCON;
                    aircon.Point = ((int)Vent_EAWADA.ONOFF).ToString();
                    room.ControlPoints.Add(aircon);
                    ControlPointData vent = new ControlPointData();
                    vent.Name = "新风" + i;
                    vent.Code = Guid.NewGuid().ToString("N");
                    vent.Brand = "EAWADA";
                    vent.Model = "E0001";
                    vent.Type = CommandUtil.CONTROLPOINT_TYPE.VENT;
                    vent.Point = ((int)Vent_EAWADA.ONOFF).ToString();
                    room.ControlPoints.Add(vent);
                }
                ret.Rooms.Add(room);
            }

            return ret;
        }
    }
}
