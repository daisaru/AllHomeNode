using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeDBConfig
{
    public class ConfigurationHelper
    {
        private static ConfigurationHelper _instance = null;

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
            SQLiteHelper sQLiteHelper = new SQLiteHelper("data source=" + dbFilePath);

            // 生成task表
            sQLiteHelper.CreateTable(strSQLTable_task);

            // 生成device表
            sQLiteHelper.CreateTable(strSQLTable_device);

            // 生成controlpoint表
            sQLiteHelper.CreateTable(strSQLTable_controlpoint);
        }

        public void GenerateDatabase(string filePath)
        {
            bool ret = NewDbFile(filePath);
        }

        /// <summary>
        /// 新建数据库文件
        /// </summary>
        /// <param name="dbPath">数据库文件路径及名称</param>
        /// <returns>新建成功，返回true，否则返回false</returns>
        private Boolean NewDbFile(string dbPath)
        {
            try
            {
                SQLiteConnection.CreateFile(dbPath);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("新建数据库文件" + dbPath + "失败：" + ex.Message);
            }
        }
    }
}
