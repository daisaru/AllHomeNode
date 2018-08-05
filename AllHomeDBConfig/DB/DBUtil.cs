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

        public List<DeviceData> GetControlPoints(string dbFilePath)
        {
            List<DeviceData> ret = new List<DeviceData>();
            List<Device> devices = new List<Device>();
            List<ControlPoint> controlpoints = new List<ControlPoint>();

            string connStr = @"Data Source=" + dbFilePath + ";Initial Catalog=sqlite;Integrated Security=True;Max Pool Size=10";

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
                        Device device = new Device();
                        device.id = reader["id"].ToString();
                        device.name = reader["name"].ToString();
                        device.type = reader["type"].ToString();
                        string time = reader["timestamp"].ToString();
                        device.timestamp = time;

                        devices.Add(device);
                    }
                }

                // 查询控制点信息
                comm.CommandText = "select * from controlpoint";
                comm.CommandType = CommandType.Text;
                using (IDataReader reader = comm.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        ControlPoint controlpoint = new ControlPoint();
                        controlpoint.id = reader["id"].ToString();
                        controlpoint.id_device = reader["id_device"].ToString();
                        controlpoint.code = reader["code"].ToString();
                        controlpoint.type = reader["type"].ToString();
                        controlpoint.subtype = reader["subtype"].ToString();
                        controlpoint.givenname = reader["givenname"].ToString();
                        controlpoint.brand = reader["brand"].ToString();
                        controlpoint.model = reader["model"].ToString();
                        controlpoint.point = reader["point"].ToString();
                        controlpoint.channel = reader["channel"].ToString();
                        controlpoint.address = reader["address"].ToString();
                        controlpoint.registergroup = reader["registergroup"].ToString();
                        controlpoint.register = reader["register"].ToString();
                        controlpoint.timestamp = reader["timestamp"].ToString();
                        controlpoint.summary = reader["summary"].ToString();

                        controlpoints.Add(controlpoint);
                    }
                }

                foreach(Device device in devices)
                {
                    DeviceData deviceData = new DeviceData();
                    deviceData.Name = device.name;
                    deviceData.Type = device.type;

                    // 获取该房间所有控制点
                    List<ControlPoint> deviceControlpoints = controlpoints.FindAll(x => x.id_device == device.id);
                    foreach(ControlPoint controlpoint in deviceControlpoints)
                    {
                        ControlPointData cp = new ControlPointData();
                        cp.Brand = controlpoint.brand;
                        cp.Code = controlpoint.code;
                        cp.Model = controlpoint.model;
                        cp.Name = controlpoint.givenname;
                        cp.Point = controlpoint.point;
                        cp.Type = controlpoint.type;

                        deviceData.ControlPoints.Add(cp);
                    }

                    ret.Add(deviceData);
                }

                conn.Close();
            }

            return ret;
        }
    }
}
