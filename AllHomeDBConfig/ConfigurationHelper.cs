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
