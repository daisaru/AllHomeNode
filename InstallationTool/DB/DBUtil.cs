using InstallationTool.Front;
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

            string connStr = @"Data Source=" + @"D:\Share\allhome.db;Initial Catalog=sqlite;Integrated Security=True;Max Pool Size=10";

            DbProviderFactory fact = DbProviderFactories.GetFactory("System.Data.SQLite.EF6");
            using (DbConnection conn = fact.CreateConnection())
            {
                conn.ConnectionString = connStr;
                conn.Open();
                DbCommand comm = conn.CreateCommand();
                comm.CommandText = "select * from devices";
                comm.CommandType = CommandType.Text;
                using (IDataReader reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string code = reader["timestamp"].ToString();
                    }
                }
            }

            return ret;
        }
    }
}
