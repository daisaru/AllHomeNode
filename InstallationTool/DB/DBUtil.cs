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

        public List<RoomData> GetControlPoints()
        {
            List<RoomData> ret = new List<RoomData>();
            List<Rooms> rooms = new List<Rooms>();
            List<Devices> devices = new List<Devices>();

            string connStr = @"Data Source=" + @"D:\Share\allhome.db;Initial Catalog=sqlite;Integrated Security=True;Max Pool Size=10";

            DbProviderFactory fact = DbProviderFactories.GetFactory("System.Data.SQLite.EF6");
            using (DbConnection conn = fact.CreateConnection())
            {
                conn.ConnectionString = connStr;
                conn.Open();

                // 查询房间信息
                DbCommand comm = conn.CreateCommand();
                comm.CommandText = "select * from rooms";
                comm.CommandType = CommandType.Text;
                using (IDataReader reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rooms room = new Rooms();
                        room.id = reader["id"].ToString();
                        room.name = reader["name"].ToString();
                        room.size = reader["size"].ToString();
                        room.timestamp = reader["timestamp"].ToString();

                        rooms.Add(room);
                    }
                }

                // 查询控制点信息
                comm.CommandText = "select * from devices";
                comm.CommandType = CommandType.Text;
                using (IDataReader reader = comm.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Devices device = new Devices();
                        device.id = reader["id"].ToString();
                        device.id_room = reader["id_room"].ToString();
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

                foreach(Rooms room in rooms)
                {
                    RoomData roomData = new RoomData();
                    roomData.Name = room.name;
                    roomData.Size = room.size;

                    // 获取该房间所有控制点
                    List<Devices> roomDevices = devices.FindAll(x => x.id_room == room.id);
                    foreach(Devices device in roomDevices)
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
