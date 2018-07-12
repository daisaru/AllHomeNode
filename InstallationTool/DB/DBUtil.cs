using InstallationTool.Front;
using InstallationTool.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallationTool.DB
{
    public class DBUtil
    {
        private static DBUtil _instance = null;

        private DBUtil()
        {
        }

        public static DBUtil Instance()
        {
            if(_instance == null)
            {
                _instance = new DBUtil();
            }

            return _instance;
        }

        public List<DeviceData> GetControlPoints()
        {
            List<DeviceData> ret = new List<DeviceData>();
            List<Device> rooms = new List<Device>();
            List<ControlPoint> devices = new List<ControlPoint>();

            string connStr = @"Data Source=" + @"D:\Share\allhome.db;Initial Catalog=sqlite;Integrated Security=True;Max Pool Size=10";

            DbProviderFactory fact = DbProviderFactories.GetFactory("System.Data.SQLite.EF6");
            using (DbConnection conn = fact.CreateConnection())
            {
                conn.ConnectionString = connStr;
                conn.Open();

                // 查询设备信息
                DbCommand comm = conn.CreateCommand();
                comm.CommandText = "select * from device";
                comm.CommandType = CommandType.Text;
                using (IDataReader reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Device room = new Device();
                        room.id = reader["id"].ToString();
                        room.name = reader["name"].ToString();
                        room.type = reader["type"].ToString();
                        room.timestamp = reader["timestamp"].ToString();

                        rooms.Add(room);
                    }
                }

                // 查询控制点信息
                comm.CommandText = "select * from controlpoint";
                comm.CommandType = CommandType.Text;
                using (IDataReader reader = comm.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        ControlPoint device = new ControlPoint();
                        device.id = reader["id"].ToString();
                        device.id_device = reader["id_device"].ToString();
                        device.code = reader["code"].ToString();
                        device.type = reader["type"].ToString();
                        device.subtype = reader["subtype"].ToString();
                        device.givenname = reader["givenname"].ToString();
                        device.brand = reader["brand"].ToString();
                        device.model = reader["model"].ToString();
                        device.point = reader["point"].ToString();
                        device.channel = reader["channel"].ToString();
                        device.address = reader["address"].ToString();
                        device.registergroup = reader["registergroup"].ToString();
                        device.register = reader["register"].ToString();
                        device.timestamp = reader["timestamp"].ToString();
                        device.summary = reader["summary"].ToString();

                        devices.Add(device);
                    }
                }

                foreach(Device room in rooms)
                {
                    DeviceData roomData = new DeviceData();
                    roomData.Name = room.name;
                    roomData.Type = room.type;

                    // 获取该房间所有控制点
                    List<ControlPoint> roomDevices = devices.FindAll(x => x.id_device == room.id);
                    foreach(ControlPoint device in roomDevices)
                    {
                        ControlPointData cp = new ControlPointData();
                        cp.Brand = device.brand;
                        cp.Code = device.code;
                        cp.Model = device.model;
                        cp.Name = device.givenname;
                        cp.Point = device.point;
                        cp.Type = device.type;

                        roomData.ControlPoints.Add(cp);
                    }

                    ret.Add(roomData);
                }

                conn.Close();
            }

            return ret;
        }
    }
}
