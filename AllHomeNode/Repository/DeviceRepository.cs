using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AllHomeNode.Front;
using AllHomeNode.Database.Manager;
using AllHomeNode.Database.Model;

namespace AllHomeNode.Repository
{
    public class DeviceRepository
    {
        public DeviceRepository()
        {

        }

        private Device FillDeviceObject(DeviceData data)
        {
            Device device = new Device();
            device.DeviceId = data.DeviceId;
            device.DeviceName = data.DeviceName;
            return device;
        }

        private DeviceData FillDeviceDataObject(Device device)
        {
            DeviceData data = new DeviceData();
            data.DeviceId = device.DeviceId;
            data.DeviceName = device.DeviceName;
            return data;
        }

        public IEnumerable<DeviceData> GetAll()
        {
            List<DeviceData> devicedata = new List<DeviceData>();
            DeviceManager deviceMgr = new DeviceManager();
            List<Device> devices = deviceMgr.GetDeviceList().ToList();
            foreach (Device device in devices)
            {
                DeviceData data = FillDeviceDataObject(device);
                devicedata.Add(data);
            }
            return devicedata;
        }

        public DeviceData Get(string deviceId)
        {
            DeviceManager deviceMgr = new DeviceManager();
            Device device = deviceMgr.GetDeviceById(deviceId).ToList()[0];
            DeviceData data = FillDeviceDataObject(device);
            return data;
        }

        public DeviceData Add(DeviceData item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("device item");
            }
            Device device = FillDeviceObject(item);
            DeviceManager deviceMgr = new DeviceManager();
            deviceMgr.Add(device);
            return item;
        }

        public bool AddHeartBeat(HeartbeatData item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("device item");
            }
            try
            {
                Heartbeat data = new Heartbeat();
                data.DeviceId = item.DeviceId;
                data.HardwareVersion = item.HardwareVersion;
                data.SoftwareVersion = item.SoftwareVersion;
                data.DeviceTime = item.DeviceTime;
                data.TimeStamp = DateTime.Now;
                DeviceManager deviceMgr = new DeviceManager();
                deviceMgr.AddHeartbeat(data);
            }
            catch(Exception exp)
            {
                Console.WriteLine("ERROR:" + exp.Message);
                return false;
            }

            return true;
        }

        public bool Update(DeviceData item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("device item");
            }
            Device device = FillDeviceObject(item);
            DeviceManager deviceMgr = new DeviceManager();
            deviceMgr.Update(device);
            return true;
        }

        public void Remove(string deviceId)
        {
            DeviceManager deviceMgr = new DeviceManager();
            deviceMgr.Delete(deviceId);
        }

        public void RevokeShareWithFriend(string friend, string deviceId)
        {
            UserManager userMgr = new UserManager();
            User user = userMgr.GetUserByMobile(friend).ToList()[0];

            DeviceManager deviceMgr = new DeviceManager();
            Device device = deviceMgr.GetDeviceByDeviceId(deviceId).ToList()[0];

            UserDeviceBindManager bindMgr = new UserDeviceBindManager();
            List<UserDeviceBind> binds = bindMgr.GetUserDeviceBindByUserId(user.Id).ToList();

            UserDeviceBind needDelete = null;
            foreach (UserDeviceBind udbind in binds)
            {
                if (udbind.Id_User == user.Id && udbind.Id_Device == device.Id)
                {
                    needDelete = udbind;
                    break;
                }
            }

            bindMgr.Delete(needDelete);
        }

        public void ShareDeviceWithFriend(string friend, string deviceId, string privilege)
        {
            UserManager userMgr = new UserManager();
            User user = userMgr.GetUserByMobile(friend).ToList()[0];

            DeviceManager deviceMgr = new DeviceManager();
            Device device = deviceMgr.GetDeviceByDeviceId(deviceId).ToList()[0];

            UserDeviceBindManager bindMgr = new UserDeviceBindManager();
            List<UserDeviceBind> binds = bindMgr.GetUserDeviceBindByUserId(user.Id).ToList();

            bool bIsUpdate = false;
            UserDeviceBind needUpdate = null;
            foreach(UserDeviceBind udbind in binds)
            {
                if(udbind.Id_User == user.Id && udbind.Id_Device == device.Id)
                {
                    bIsUpdate = true;
                    needUpdate = udbind;
                    break;
                }
            }

            if(bIsUpdate)
            {
                needUpdate.Privilege = privilege;
                needUpdate.TimeStamp = DateTime.Now;

                bindMgr.Update(needUpdate);
            }
            else
            {
                UserDeviceBind bind = new UserDeviceBind();
                bind.Id = Guid.NewGuid().ToString("N");
                bind.Id_Device = device.Id;
                bind.Id_User = user.Id;
                bind.Privilege = privilege;
                bind.DeviceGivenName = device.DeviceName;
                bind.TimeStamp = DateTime.Now;

                bindMgr.Add(bind);
            }
        }

        public void BindDeviceWithUser(string mobile, string deviceId, string deviceName)
        {
            UserManager userMgr = new UserManager();
            User user = userMgr.GetUserByMobile(mobile).ToList()[0];

            DeviceManager deviceMgr = new DeviceManager();
            Device device = deviceMgr.GetDeviceByDeviceId(deviceId).ToList()[0];
            string id = device.Id;

            UserDeviceBindManager bindMgr = new UserDeviceBindManager();

            List<UserDeviceBind> binds = bindMgr.GetUserDeviceBindByUserId(user.Id).ToList();
            if(binds.Count > 0)
            {
                foreach(UserDeviceBind udbind in binds)
                {
                    if(udbind.Id_Device == id)
                    {
                        udbind.DeviceGivenName = deviceName;
                        udbind.TimeStamp = DateTime.Now;

                        bindMgr.Update(udbind);
                    }
                }
            }
            else
            {
                UserDeviceBind bind = new UserDeviceBind();
                bind.Id = Guid.NewGuid().ToString("N");
                bind.Id_Device = device.Id;
                bind.Id_User = user.Id;
                bind.Privilege = CommandUtil.PRIVILEGE.ADMIN;
                bind.DeviceGivenName = deviceName;
                bind.TimeStamp = DateTime.Now;

                bindMgr.Add(bind);
            }
        }

        public IEnumerable<UserDeviceData> GetAllBindDevices(string mobile)
        {
            List<UserDeviceData> datas = new List<UserDeviceData>();
            UserManager userManager = new UserManager();
            User user = userManager.GetUserByMobile(mobile).ToList()[0];
            UserDeviceBindManager userDeviceBindManager = new UserDeviceBindManager();
            List<UserDeviceBind> userdevices = userDeviceBindManager.GetUserDeviceBindByUserId(user.Id).ToList();
            foreach(UserDeviceBind userdevicebind in userdevices)
            {
                UserDeviceData data = new UserDeviceData();

                string id_device = userdevicebind.Id_Device;
                DeviceManager deviceManager = new DeviceManager();
                Device device = deviceManager.GetDeviceById(id_device).ToList()[0];
                data.DeviceId = device.DeviceId;
                data.DeviceName = userdevicebind.DeviceGivenName;
                data.Privilege = userdevicebind.Privilege;

                datas.Add(data);
            }
            return datas;
        }

        private ControlPoint FillControlPointObject(ControlPointData item, string idRoom)
        {
            ControlPoint cp = new ControlPoint();
            cp.Id = Guid.NewGuid().ToString("N");
            cp.Id_Room = idRoom;
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

        public IEnumerable<RoomData> GetAllControlPoints(string deviceId)
        {
            DeviceManager deviceMgr = new DeviceManager();
            Device device = deviceMgr.GetDeviceByDeviceId(deviceId).ToList()[0];

            DeviceRoomBindManager drBindMgr = new DeviceRoomBindManager();
            List<DeviceRoomBind> drBinds = drBindMgr.GetControlPointByDeviceId(device.Id).ToList();

            RoomManager roomMgr = new RoomManager();
            ControlPointManager cpMgr = new ControlPointManager();

            List<RoomData> result = new List<RoomData>();
            foreach(DeviceRoomBind drBind in drBinds)
            {
                string idRoom = drBind.Id_Room;
                Room room = roomMgr.GetRoomByRoomId(idRoom).ToList()[0];

                RoomData roomData = new RoomData();
                roomData.Name = room.Name;

                List<ControlPoint> contolpoints = cpMgr.GetControlPointByRoom(idRoom).ToList();
                List<ControlPointData> controlpointdata = roomData.ControlPoints;
                foreach(ControlPoint cp in contolpoints)
                {
                    ControlPointData cpData = FillControlPointDataObject(cp);
                    controlpointdata.Add(cpData);
                }

                result.Add(roomData);
            }

            return result;
        }

        public bool RegisterDevice(string deviceId, string deviceName)
        {
            DeviceManager devMgr = new DeviceManager();
            List<Device> devices = devMgr.GetDeviceByDeviceId(deviceId).ToList();

            if(devices.Count == 0)
            {
                // new register
                Device dev = new Device();
                dev.Id = Guid.NewGuid().ToString("N");
                dev.DeviceId = deviceId;
                dev.DeviceName = deviceName;
                dev.TimeStamp = DateTime.Now;

                devMgr.Add(dev);
            }

            return true;
        }

        public bool UploadCtrlPoints(string deviceId, List<RoomData> rooms)
        {
            DeviceManager devMgr = new DeviceManager();
            Device dev = devMgr.GetDeviceByDeviceId(deviceId).ToList()[0];

            RoomManager roomMgr = new RoomManager();
            DeviceRoomBindManager drBindMgr = new DeviceRoomBindManager();
            ControlPointManager cpMgr = new ControlPointManager();

            foreach(RoomData r in rooms)
            {
                Room roomTmp = new Room();
                roomTmp.Id = Guid.NewGuid().ToString("N");
                roomTmp.Name = r.Name;
                roomTmp.TimeStamp = DateTime.Now;

                roomMgr.Add(roomTmp);

                DeviceRoomBind drBindTmp = new DeviceRoomBind();
                drBindTmp.Id = Guid.NewGuid().ToString("N");
                drBindTmp.Id_Device = dev.Id;
                drBindTmp.Id_Room = roomTmp.Id;
                drBindTmp.TimeStamp = DateTime.Now;

                drBindMgr.Add(drBindTmp);

                List<ControlPointData> controlpoints = r.ControlPoints;
                foreach(ControlPointData cpdata in controlpoints)
                {
                    ControlPoint cp = FillControlPointObject(cpdata, roomTmp.Id);
                    cpMgr.Add(cp);
                }
            }

            return true;
        }
    }
}
