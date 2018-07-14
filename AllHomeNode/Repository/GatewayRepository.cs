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
            return device;
        }

        private GatewayData FillDeviceDataObject(Gateway device)
        {
            GatewayData data = new GatewayData();
            data.GatewayId = device.GatewayId;
            data.GatewayName = device.GatewayName;
            return data;
        }

        public IEnumerable<GatewayData> GetAll()
        {
            List<GatewayData> devicedata = new List<GatewayData>();
            GatewayManager deviceMgr = new GatewayManager();
            List<Gateway> devices = deviceMgr.GetDeviceList().ToList();
            foreach (Gateway device in devices)
            {
                GatewayData data = FillDeviceDataObject(device);
                devicedata.Add(data);
            }
            return devicedata;
        }

        public GatewayData Get(string deviceId)
        {
            GatewayManager deviceMgr = new GatewayManager();
            Gateway device = deviceMgr.GetDeviceById(deviceId).ToList()[0];
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

        public void Remove(string deviceId)
        {
            GatewayManager deviceMgr = new GatewayManager();
            deviceMgr.Delete(deviceId);
        }

        public IEnumerable<GatewayShareData> GetDeviceShareData(string mobile, string deviceId)
        {
            List<GatewayShareData> datas = new List<GatewayShareData>();

            UserManager userManager = new UserManager();
            User user = userManager.GetUserByMobile(mobile).ToList()[0];

            GatewayManager deviceMgr = new GatewayManager();
            Gateway device = deviceMgr.GetDeviceByDeviceId(deviceId).ToList()[0];

            UserGatewayBindManager userDeviceBindManager = new UserGatewayBindManager();
            List<UserGatewayBind> userdevices = userDeviceBindManager.GetUserDeviceBindByUserIdAndDeviceId(user.Id, device.Id).ToList();

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

        public void RevokeShareWithFriend(string friend, string deviceId)
        {
            UserManager userMgr = new UserManager();
            User user = userMgr.GetUserByMobile(friend).ToList()[0];

            GatewayManager deviceMgr = new GatewayManager();
            Gateway device = deviceMgr.GetDeviceByDeviceId(deviceId).ToList()[0];

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

        public void ShareGatewayWithFriend(string friend, string deviceId, string privilege, string time)
        {
            UserManager userMgr = new UserManager();
            User user = userMgr.GetUserByMobile(friend).ToList()[0];

            GatewayManager deviceMgr = new GatewayManager();
            Gateway device = deviceMgr.GetDeviceByDeviceId(deviceId).ToList()[0];

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

        public void BindDeviceWithUser(string mobile, string deviceId, string deviceName)
        {
            UserManager userMgr = new UserManager();
            User user = userMgr.GetUserByMobile(mobile).ToList()[0];

            GatewayManager deviceMgr = new GatewayManager();
            Gateway device = deviceMgr.GetDeviceByDeviceId(deviceId).ToList()[0];
            string id = device.Id;

            UserGatewayBindManager bindMgr = new UserGatewayBindManager();

            List<UserGatewayBind> binds = bindMgr.GetUserDeviceBindByUserId(user.Id).ToList();
            if (binds.Count > 0)
            {
                foreach (UserGatewayBind udbind in binds)
                {
                    if (udbind.Id_Gateway == id)
                    {
                        udbind.GatewayGivenName = deviceName;
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
                bind.GatewayGivenName = deviceName;
                bind.TimeStamp = DateTime.Now;

                bindMgr.Add(bind);
            }
        }

        public IEnumerable<UserGatewayData> GetAllBindGateway(string mobile)
        {
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
                Gateway device = deviceManager.GetDeviceById(id_device).ToList()[0];
                data.GatewayId = device.GatewayId;
                data.GatewayName = userdevicebind.GatewayGivenName;
                data.Privilege = userdevicebind.Privilege;

                datas.Add(data);
            }
            return datas;
        }

        private ControlPoint FillControlPointObject(ControlPointData item, string idRoom)
        {
            ControlPoint cp = new ControlPoint();
            cp.Id = Guid.NewGuid().ToString("N");
            cp.Id_Device = idRoom;
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

        public IEnumerable<DeviceData> GetAllControlPoints(string deviceId)
        {
            GatewayManager deviceMgr = new GatewayManager();
            Gateway device = deviceMgr.GetDeviceByDeviceId(deviceId).ToList()[0];

            GatewayDeviceBindManager drBindMgr = new GatewayDeviceBindManager();
            List<GatewayDeviceBind> drBinds = drBindMgr.GetControlPointByDeviceId(device.Id).ToList();

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

        public bool RegisterGateway(string deviceId, string deviceName)
        {
            GatewayManager devMgr = new GatewayManager();
            List<Gateway> devices = devMgr.GetDeviceByDeviceId(deviceId).ToList();

            if (devices.Count == 0)
            {
                // new register
                Gateway dev = new Gateway();
                dev.Id = Guid.NewGuid().ToString("N");
                dev.GatewayId = deviceId;
                dev.GatewayName = deviceName;
                dev.TimeStamp = DateTime.Now;

                devMgr.Add(dev);
            }

            return true;
        }

        public bool UploadCtrlPoints(string deviceId, List<DeviceData> rooms)
        {
            GatewayManager devMgr = new GatewayManager();
            Gateway dev = devMgr.GetDeviceByDeviceId(deviceId).ToList()[0];

            DeviceManager roomMgr = new DeviceManager();
            GatewayDeviceBindManager drBindMgr = new GatewayDeviceBindManager();
            ControlPointManager cpMgr = new ControlPointManager();

            foreach (DeviceData r in rooms)
            {
                Device roomTmp = new Device();
                roomTmp.Id = Guid.NewGuid().ToString("N");
                roomTmp.Name = r.Name;
                roomTmp.Type = r.Type;
                roomTmp.TimeStamp = DateTime.Now;

                roomMgr.Add(roomTmp);

                GatewayDeviceBind drBindTmp = new GatewayDeviceBind();
                drBindTmp.Id = Guid.NewGuid().ToString("N");
                drBindTmp.Id_Gateway = dev.Id;
                drBindTmp.Id_Device = roomTmp.Id;
                drBindTmp.TimeStamp = DateTime.Now;

                drBindMgr.Add(drBindTmp);

                List<ControlPointData> controlpoints = r.ControlPoints;
                foreach (ControlPointData cpdata in controlpoints)
                {
                    ControlPoint cp = FillControlPointObject(cpdata, roomTmp.Id);
                    cpMgr.Add(cp);
                }
            }

            return true;
        }
    }
}
