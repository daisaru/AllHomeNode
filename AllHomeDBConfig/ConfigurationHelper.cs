using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeDBConfig
{
    public class ConfigurationHelper
    {
        private static ConfigurationHelper _instance = null;
        private SQLiteHelper sQLiteHelper = null;
        private SQLiteHelper tempSQLiteHelper = null;

        private string _configFilePath = "";

        #region SQL
        private const string strSQLTable_task = "CREATE TABLE IF NOT EXISTS task (" +
                                                "id VARCHAR(50)  PRIMARY KEY NOT NULL," +
                                                "taskdata  VARCHAR(500)," +
                                                "timestamp DATETIME);";

        private const string strSQLTable_device = "CREATE TABLE IF NOT EXISTS device (" +
                                                  "id VARCHAR(50) PRIMARY KEY NOT NULL," + 
                                                  "name      VARCHAR(50)," +
                                                  "type      VARCHAR(50)," +
                                                  "timestamp DATETIME" +
                                                  ");";

        private const string strSQLTable_controlpoint = "CREATE TABLE IF NOT EXISTS controlpoint (" +
                                                        "id            INTEGER      PRIMARY KEY AUTOINCREMENT NOT NULL," +
                                                        "id_device     VARCHAR (50) NOT NULL," +
                                                        "code          VARCHAR (50) NOT NULL UNIQUE," +
                                                        "type          VARCHAR (50) NOT NULL," +
                                                        "subtype       VARCHAR (50)," +
                                                        "givenname     VARCHAR (50)," +
                                                        "brand         VARCHAR (50)," +
                                                        "model         VARCHAR (50)," +
                                                        "point         VARCHAR (50) NOT NULL," +
                                                        "channel       VARCHAR (50) NOT NULL," +
                                                        "address       VARCHAR (50) NOT NULL," +
                                                        "registergroup VARCHAR (50)," +
                                                        "register      VARCHAR (50) NOT NULL," +
                                                        "timestamp     DATETIME," +
                                                        "summary       VARCHAR (50));";
        #endregion

        private ConfigurationHelper()
        {
            tempSQLiteHelper = new SQLiteHelper("data source=template.db");
        }

        public static ConfigurationHelper Instance()
        {
            if(_instance == null)
            {
                _instance = new ConfigurationHelper();
            }

            return _instance;
        }

        public void GenerateDBTables(string dbFilePath)
        {
            sQLiteHelper = new SQLiteHelper("data source=" + dbFilePath);

            // 生成task表
            sQLiteHelper.CreateTable(strSQLTable_task);

            // 生成device表
            sQLiteHelper.CreateTable(strSQLTable_device);

            // 生成controlpoint表
            sQLiteHelper.CreateTable(strSQLTable_controlpoint);
        }

        public bool GenerateDatabase(string filePath)
        {
            try
            {
                SQLiteConnection.CreateFile(filePath);
                _configFilePath = filePath + ".txt";
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("新建数据库文件" + filePath + "失败：" + ex.Message);
            }
        }

        public string InsertDeviceAndControlpoints(string name, string devType, string indexCode, string modbusAddr)
        {
            StreamWriter sw = new StreamWriter(_configFilePath, true, Encoding.UTF8);

            string id = Guid.NewGuid().ToString("N");
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            SQLiteDataReader tempReader = sQLiteHelper.InsertValues("device", new string[] {id, name, devType, time});

            string querySQL = "";

            switch(devType)
            {
                case Utility.DEV_TYPE_GATEWAY:
                    {
                        querySQL = Controlpoint.GetSelectSQL(Utility.DEVID_GATEWAY);
                        break;
                    }
                case Utility.DEV_TYPE_METER_POWER:
                    {
                        sw.WriteLine(indexCode + "  名称：" + name + "         类型：电量计量" + "        RS485地址： " + modbusAddr);
                        querySQL = Controlpoint.GetSelectSQL(Utility.DEVID_METER_POWER);
                        break;
                    }
                case Utility.DEV_TYPE_VENT:
                    {
                        sw.WriteLine(indexCode + "  名称：" + name + "         类型：新风系统" + "        Modbus地址： " + modbusAddr);
                        querySQL = Controlpoint.GetSelectSQL(Utility.DEVID_VENT);
                        break;
                    }
                case Utility.DEV_TYPE_AIRCON:
                    {
                        sw.WriteLine(indexCode + "  名称：" + name + "         类型：空气源主机" + "       Modbus地址： " + modbusAddr);
                        querySQL = Controlpoint.GetSelectSQL(Utility.DEVID_AIRCON);
                        break;
                    }
                case Utility.DEV_TYPE_CTRL_AIR:
                    {
                        sw.WriteLine(indexCode + "  名称：" + name + "         类型：空调面板" + "        Modbus地址： " + modbusAddr);
                        querySQL = Controlpoint.GetSelectSQL(Utility.DEV_TYPE_CTRL_AIR);
                        break;
                    }
                case Utility.DEV_TYPE_CTRL_HEAT:
                    {
                        sw.WriteLine(indexCode + "  名称：" + name + "         类型：地暖面板" + "        Modbus地址： " + modbusAddr);
                        querySQL = Controlpoint.GetSelectSQL(Utility.DEVID_CTRL_HEAT);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            tempReader = tempSQLiteHelper.ExecuteSQL(querySQL);
            while(tempReader.Read())
            {
                string id_device = tempReader["id_device"].ToString();
                string code = "";
                if(devType == Utility.DEV_TYPE_GATEWAY)
                {
                    code = tempReader["code"].ToString();
                }
                else
                {
                    code = indexCode + "_" + tempReader["code"].ToString();
                }
                string type = tempReader["type"].ToString();
                string subtype = tempReader["subtype"].ToString();
                string givenname = tempReader["givenname"].ToString();
                string brand = tempReader["brand"].ToString();
                string model = tempReader["model"].ToString();
                string point = tempReader["point"].ToString();
                string channel = tempReader["channel"].ToString();
                string address = modbusAddr;
                string registergroup = tempReader["registergroup"].ToString();
                string register = tempReader["register"].ToString();
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string summary = tempReader["summary"].ToString();

                string insertSQL = Controlpoint.GetInsertSQL(id,
                                                             code,
                                                             type,
                                                             subtype,
                                                             givenname,
                                                             brand,
                                                             model,
                                                             point,
                                                             channel,
                                                             address,
                                                             registergroup,
                                                             register,
                                                             timestamp,
                                                             summary);

                SQLiteDataReader insertRet = sQLiteHelper.ExecuteQuery(insertSQL);
            }

            sw.Flush();
            sw.Close();

            return id;
        }
    }
}
