using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AllHomeNode.Front;
using AllHomeNode.Database.Manager;
using AllHomeNode.Database.Model;
using AllHomeNode.Service.MQTT.Device;

namespace AllHomeNode.Repository
{
    public class GatewayRepository
    {
        public GatewayRepository()
        {

        }

        private Gateway FillDeviceObject(GatewayData data)
        {
            Gateway device = new Gateway();
            device.GatewayId = data.GatewayId;
            device.GatewayName = data.GatewayName;
            device.PowerBase = "0";
            return device;
        }

        private GatewayData FillDeviceDataObject(Gateway gateway)
        {
            GatewayData data = new GatewayData();
            data.GatewayId = gateway.GatewayId;
            data.GatewayName = gateway.GatewayName;
            return data;
        }

        public IEnumerable<GatewayData> GetAll()
        {
            List<GatewayData> devicedata = new List<GatewayData>();
            GatewayManager deviceMgr = new GatewayManager();
            List<Gateway> devices = deviceMgr.GetGatewayList().ToList();
            foreach (Gateway device in devices)
            {
                GatewayData data = FillDeviceDataObject(device);
                devicedata.Add(data);
            }
            return devicedata;
        }

        public GatewayData Get(string gateway)
        {
            GatewayManager deviceMgr = new GatewayManager();
            Gateway device = deviceMgr.GetGatewayById(gateway).ToList()[0];
            GatewayData data = FillDeviceDataObject(device);
            return data;
        }

        public GatewayData Add(GatewayData item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("device item");
            }
            Gateway device = FillDeviceObject(item);
            GatewayManager deviceMgr = new GatewayManager();
            deviceMgr.Add(device);
            return item;
        }

        public bool AddHeartBeat(HeartbeatData item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("AddHeartBeat");
            }
            try
            {
                Heartbeat data = new Heartbeat();
                data.GatewayId = item.GatewayId;
                data.HardwareVersion = item.HardwareVersion;
                data.SoftwareVersion = item.SoftwareVersion;
                data.DeviceTime = item.GatewayTime;
                data.TimeStamp = DateTime.Now;
                GatewayManager deviceMgr = new GatewayManager();
                deviceMgr.AddHeartbeat(data);
            }
            catch (Exception exp)
            {
                Console.WriteLine("ERROR:" + exp.Message);
                return false;
            }

            return true;
        }

        public bool Update(GatewayData item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("device item");
            }
            Gateway device = FillDeviceObject(item);
            GatewayManager deviceMgr = new GatewayManager();
            deviceMgr.Update(device);
            return true;
        }

        public void Remove(string GatewayId)
        {
            GatewayManager deviceMgr = new GatewayManager();
            deviceMgr.Delete(GatewayId);
        }

        public IEnumerable<GatewayShareData> GetGatewayShareData(string mobile, string gateway)
        {
            List<GatewayShareData> datas = new List<GatewayShareData>();

            UserManager userManager = new UserManager();
            User user = userManager.GetUserByMobile(mobile).ToList()[0];

            GatewayManager deviceMgr = new GatewayManager();
            Gateway device = deviceMgr.GetGatewayByGatewayIdentifier(gateway).ToList()[0];

            UserGatewayBindManager userDeviceBindManager = new UserGatewayBindManager();
            List<UserGatewayBind> userdevices = userDeviceBindManager.GetUserGatewayBindByUserIdAndGatewayId(user.Id, device.Id).ToList();

            foreach (UserGatewayBind userdevicebind in userdevices)
            {
                GatewayShareData data = new GatewayShareData();
                data.Time = userdevicebind.Time;
                data.Privilege = userdevicebind.Privilege;

                User friend = userManager.GetUser(userdevicebind.Id_User).ToList()[0];
                data.UserId = friend.Mobile;

                if(data.Time.Equals("0") == false)
                {
                    DateTime overTime = DateTime.Parse(data.Time);
                    if(DateTime.Now < overTime)
                    {
                        datas.Add(data);
                    }
                }
                else
                {
                    datas.Add(data);
                }
            }
            return datas;
        }

        public void RevokeShareWithFriend(string friend, string gateway)
        {
            UserManager userMgr = new UserManager();
            User user = userMgr.GetUserByMobile(friend).ToList()[0];

            GatewayManager deviceMgr = new GatewayManager();
            Gateway device = deviceMgr.GetGatewayByGatewayIdentifier(gateway).ToList()[0];

            UserGatewayBindManager bindMgr = new UserGatewayBindManager();
            List<UserGatewayBind> binds = bindMgr.GetUserDeviceBindByUserId(user.Id).ToList();

            UserGatewayBind needDelete = null;
            foreach (UserGatewayBind udbind in binds)
            {
                if (udbind.Id_User == user.Id && udbind.Id_Gateway == device.Id)
                {
                    needDelete = udbind;
                    break;
                }
            }

            bindMgr.Delete(needDelete);
        }

        public void ShareGatewayWithFriend(string friend, string gateway, string privilege, string time)
        {
            UserManager userMgr = new UserManager();
            User user = userMgr.GetUserByMobile(friend).ToList()[0];

            GatewayManager deviceMgr = new GatewayManager();
            Gateway device = deviceMgr.GetGatewayByGatewayIdentifier(gateway).ToList()[0];

            UserGatewayBindManager bindMgr = new UserGatewayBindManager();
            List<UserGatewayBind> binds = bindMgr.GetUserDeviceBindByUserId(user.Id).ToList();

            bool bIsUpdate = false;
            UserGatewayBind needUpdate = null;
            foreach (UserGatewayBind udbind in binds)
            {
                if (udbind.Id_User == user.Id && udbind.Id_Gateway == device.Id)
                {
                    bIsUpdate = true;
                    needUpdate = udbind;
                    break;
                }
            }

            if (bIsUpdate)
            {
                needUpdate.Privilege = privilege;
                if(time.Equals("0") == false)
                {
                    needUpdate.Time = DateTime.Now.AddHours(int.Parse(time)).ToString();
                }
                else
                {
                    needUpdate.Time = time;
                }

                needUpdate.TimeStamp = DateTime.Now;

                bindMgr.Update(needUpdate);
            }
            else
            {
                UserGatewayBind bind = new UserGatewayBind();
                bind.Id = Guid.NewGuid().ToString("N");
                bind.Id_Gateway = device.Id;
                bind.Id_User = user.Id;
                bind.Privilege = privilege;

                if (time.Equals("0") == false)
                {
                    bind.Time = DateTime.Now.AddHours(int.Parse(time)).ToString();
                }
                else
                {
                    bind.Time = time;
                }

                bind.GatewayGivenName = device.GatewayName;
                bind.TimeStamp = DateTime.Now;

                bindMgr.Add(bind);
            }
        }

        public void UpdateDeviceInfoById(string deviceId, string deviceName)
        {
            DeviceManager deviceMgr = new DeviceManager();

            Device device = deviceMgr.GetDeviceByDeviceId(deviceId)[0];
            device.Name = deviceName;
            device.TimeStamp = DateTime.Now;

            deviceMgr.Update(device);
        }

        public void BindGatewayWithUser(string mobile, string gatewayId, string gatewayName)
        {
            UserManager userMgr = new UserManager();
            User user = userMgr.GetUserByMobile(mobile).ToList()[0];

            GatewayManager deviceMgr = new GatewayManager();
            Gateway device = deviceMgr.GetGatewayByGatewayIdentifier(gatewayId).ToList()[0];
            string id = device.Id;

            UserGatewayBindManager bindMgr = new UserGatewayBindManager();

            List<UserGatewayBind> binds = bindMgr.GetUserDeviceBindByUserId(user.Id).ToList();
            if (binds.Count > 0)
            {
                foreach (UserGatewayBind udbind in binds)
                {
                    if (udbind.Id_Gateway == id)
                    {
                        udbind.GatewayGivenName = gatewayName;
                        udbind.TimeStamp = DateTime.Now;

                        bindMgr.Update(udbind);
                    }
                }
            }
            else
            {
                UserGatewayBind bind = new UserGatewayBind();
                bind.Id = Guid.NewGuid().ToString("N");
                bind.Id_Gateway = device.Id;
                bind.Id_User = user.Id;
                bind.Privilege = CommandUtil.PRIVILEGE.ADMIN;
                bind.Time = "0";
                bind.GatewayGivenName = gatewayName;
                bind.TimeStamp = DateTime.Now;

                bindMgr.Add(bind);
            }
        }

        public IEnumerable<UserGatewayData> GetAllBindGateway(string mobile)
        {
            HeartbeatManager heartbeatManager = new HeartbeatManager();
            DateTime timeStart = DateTime.Now.AddMinutes(-20);
            DateTime timeEnd = DateTime.Now;

            List<UserGatewayData> datas = new List<UserGatewayData>();
            UserManager userManager = new UserManager();
            User user = userManager.GetUserByMobile(mobile).ToList()[0];
            UserGatewayBindManager userDeviceBindManager = new UserGatewayBindManager();
            List<UserGatewayBind> userdevices = userDeviceBindManager.GetUserDeviceBindByUserId(user.Id).ToList();
            foreach (UserGatewayBind userdevicebind in userdevices)
            {
                UserGatewayData data = new UserGatewayData();

                string id_device = userdevicebind.Id_Gateway;
                GatewayManager deviceManager = new GatewayManager();
                Gateway device = deviceManager.GetGatewayById(id_device).ToList()[0];
                data.GatewayId = device.GatewayId;
                data.GatewayName = userdevicebind.GatewayGivenName;
                data.Privilege = userdevicebind.Privilege;

                // 20分钟内无心跳认为网关不在线
                List<Heartbeat> heartbeats = heartbeatManager.GetHeartbeats(data.GatewayId, timeStart, timeEnd).ToList();
                if (heartbeats.Count > 0)
                {
                    data.OnineState = CommandUtil.ONLINE_STATE.ONLINE;
                }
                else
                {
                    data.OnineState = CommandUtil.ONLINE_STATE.OFFLINE;
                }

                datas.Add(data);
            }
            return datas;
        }

        private ControlPoint FillControlPointObject(ControlPointData item, string deviceId)
        {
            ControlPoint cp = new ControlPoint();
            cp.Id = Guid.NewGuid().ToString("N");
            cp.Id_Device = deviceId;
            cp.Code = item.Code;
            cp.Point = item.Point;
            cp.Name = item.Name;
            cp.Brand = item.Brand;
            cp.Type = item.Type;
            cp.Model = item.Model;
            cp.TimeStamp = DateTime.Now;

            return cp;
        }

        private ControlPointData FillControlPointDataObject(ControlPoint item)
        {
            ControlPointData data = new ControlPointData();
            data.Code = item.Code;
            data.Name = item.Name;
            data.Type = item.Type;
            data.Brand = item.Brand;
            data.Model = item.Model;
            data.Point = item.Point;
            return data;
        }

        public ControlPointData GetControlPointByCode(string code)
        {
            ControlPointManager cpMgr = new ControlPointManager();
            List<ControlPoint> cps = cpMgr.GetControlPointByCode(code).ToList();
            ControlPointData ret = FillControlPointDataObject(cps[0]);
            return ret;
        }

        public IEnumerable<DeviceData> GetAllControlPoints(string gatewayId)
        {
            GatewayManager deviceMgr = new GatewayManager();
            Gateway device = deviceMgr.GetGatewayByGatewayIdentifier(gatewayId).ToList()[0];

            GatewayDeviceBindManager drBindMgr = new GatewayDeviceBindManager();
            List<GatewayDeviceBind> drBinds = drBindMgr.GetBindsByGatewayId(device.Id).ToList();

            DeviceManager roomMgr = new DeviceManager();
            ControlPointManager cpMgr = new ControlPointManager();

            List<DeviceData> result = new List<DeviceData>();
            foreach (GatewayDeviceBind drBind in drBinds)
            {
                string idRoom = drBind.Id_Device;
                Device room = roomMgr.GetDeviceByDeviceId(idRoom).ToList()[0];

                DeviceData deviceData = new DeviceData();
                deviceData.DeviceId = room.Id;
                deviceData.Name = room.Name;
                deviceData.Type = room.Type;

                List<ControlPoint> contolpoints = cpMgr.GetControlPointByRoom(idRoom).ToList();
                List<ControlPointData> controlpointdata = deviceData.ControlPoints;
                foreach (ControlPoint cp in contolpoints)
                {
                    ControlPointData cpData = FillControlPointDataObject(cp);
                    controlpointdata.Add(cpData);
                }

                result.Add(deviceData);
            }

            return result;
        }

        public bool RegisterGateway(string gatewayId, string gatewayName)
        {
            GatewayManager devMgr = new GatewayManager();
            List<Gateway> devices = devMgr.GetGatewayByGatewayIdentifier(gatewayId).ToList();

            if (devices.Count == 0)
            {
                // new register
                Gateway dev = new Gateway();
                dev.Id = Guid.NewGuid().ToString("N");
                dev.GatewayId = gatewayId;
                dev.GatewayName = gatewayName;
                dev.PowerBase = "0";
                dev.TimeStamp = DateTime.Now;

                devMgr.Add(dev);
            }

            return true;
        }

        public bool AddDeviceToGateway(string gateway, DeviceData device)
        {
            GatewayManager gtwMgr = new GatewayManager();
            Gateway dev = gtwMgr.GetGatewayByGatewayIdentifier(gateway).ToList()[0];

            DeviceManager deviceMgr = new DeviceManager();
            GatewayDeviceBindManager drBindMgr = new GatewayDeviceBindManager();
            ControlPointManager cpMgr = new ControlPointManager();

            try
            {
                Device deviceTmp = new Device();
                deviceTmp.Id = Guid.NewGuid().ToString("N");
                deviceTmp.Name = device.Name;
                deviceTmp.Type = device.Type;
                deviceTmp.TimeStamp = DateTime.Now;

                deviceMgr.Add(deviceTmp);

                GatewayDeviceBind drBindTmp = new GatewayDeviceBind();
                drBindTmp.Id = Guid.NewGuid().ToString("N");
                drBindTmp.Id_Gateway = dev.Id;
                drBindTmp.Id_Device = deviceTmp.Id;
                drBindTmp.TimeStamp = DateTime.Now;

                drBindMgr.Add(drBindTmp);

                List<ControlPointData> controlpoints = device.ControlPoints;
                foreach (ControlPointData cpdata in controlpoints)
                {
                    ControlPoint cp = FillControlPointObject(cpdata, deviceTmp.Id);
                    cpMgr.Add(cp);
                }
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.Message);
                return false;
            }

            return true;
        }

        public bool UploadCtrlPoints(string gateway, List<DeviceData> devices)
        {
            GatewayManager gtwMgr = new GatewayManager();
            Gateway dev = gtwMgr.GetGatewayByGatewayIdentifier(gateway).ToList()[0];

            DeviceManager deviceMgr = new DeviceManager();
            GatewayDeviceBindManager drBindMgr = new GatewayDeviceBindManager();
            ControlPointManager cpMgr = new ControlPointManager();

            try
            { 
                foreach (DeviceData r in devices)
                {
                    Device deviceTmp = new Device();
                    deviceTmp.Id = Guid.NewGuid().ToString("N");
                    deviceTmp.Name = r.Name;
                    deviceTmp.Type = r.Type;
                    deviceTmp.TimeStamp = DateTime.Now;

                    deviceMgr.Add(deviceTmp);

                    GatewayDeviceBind drBindTmp = new GatewayDeviceBind();
                    drBindTmp.Id = Guid.NewGuid().ToString("N");
                    drBindTmp.Id_Gateway = dev.Id;
                    drBindTmp.Id_Device = deviceTmp.Id;
                    drBindTmp.TimeStamp = DateTime.Now;

                    drBindMgr.Add(drBindTmp);

                    List<ControlPointData> controlpoints = r.ControlPoints;
                    foreach (ControlPointData cpdata in controlpoints)
                    {
                        ControlPoint cp = FillControlPointObject(cpdata, deviceTmp.Id);
                        cpMgr.Add(cp);
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                return false;
            }

            return true;
        }

        public bool CheckRight(string mobile, string gateway)
        {
            bool ret = false;

            GatewayManager gatewayMgr = new GatewayManager();
            Gateway gtw = gatewayMgr.GetGatewayByGatewayIdentifier(gateway).ToList()[0];
            UserManager userMgr = new UserManager();
            User user = userMgr.GetUserByMobile(mobile).ToList()[0];
            UserGatewayBindManager userGatewayBindMgr = new UserGatewayBindManager();
            UserGatewayBind usergatewayBind = userGatewayBindMgr.GetUserGatewayBindByUserIdAndGatewayId(user.Id, gtw.Id).ToList()[0];
            if(usergatewayBind.Privilege == CommandUtil.PRIVILEGE.ADMIN)
            {
                ret = true;
            }

            return ret;
        }

        public bool DeleteAllDeviceFromGateway(string gateway)
        {
            GatewayManager gatewayMgr = new GatewayManager();
            DeviceManager deviceMgr = new DeviceManager();
            GatewayDeviceBindManager gatewayDeviceBindMgr = new GatewayDeviceBindManager();
            ControlPointManager controlPointMgr = new ControlPointManager();

            // 找到网关
            Gateway gtw = gatewayMgr.GetGatewayByGatewayIdentifier(gateway).ToList()[0];

            bool ret = false;
            List<GatewayDeviceBind> devicesBinds = gatewayDeviceBindMgr.GetBindsByGatewayId(gtw.Id).ToList();
            foreach(GatewayDeviceBind devicebind in devicesBinds)
            {
                string deviceId = devicebind.Id_Device;

                // 删除所有的CP
                ret = controlPointMgr.Delete(deviceId);
                if (ret == false)
                {
                    return false;
                }

                // 删除device
                ret = deviceMgr.Delete(deviceId);
                if (ret == false)
                {
                    return false;
                }

                // 删除绑定
                ret = gatewayDeviceBindMgr.Delete(deviceId);
                if (ret == false)
                {
                    return false;
                }
            }

            return ret;
        }

        public bool DeleteDeviceFromGateway(string deviceId)
        {
            DeviceManager deviceMgr = new DeviceManager();
            GatewayDeviceBindManager gatewayDeviceBindMgr = new GatewayDeviceBindManager();
            ControlPointManager controlPointMgr = new ControlPointManager();

            // 删除该设备所有的CP
            bool ret = controlPointMgr.Delete(deviceId);
            if(ret == false)
            {
                return false;
            }

            // 删除设备和网关绑定信息
            ret = gatewayDeviceBindMgr.Delete(deviceId);
            if(ret == false)
            {
                return false;
            }

            // 删除设备信息
            ret = deviceMgr.Delete(deviceId);
            if(ret == false)
            {
                return false;
            }

            return true;
        }
    }
}
