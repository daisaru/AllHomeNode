using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeDBConfig
{
    public class Device
    {
        public static string GetSelectSQL()
        {
            string sql = "SELECT id," +
                                "name," +
                                "type," +
                                "timestamp " +
                                "FROM device;";
            return sql;
        }

        public static string GetInsertSQL(string id, 
                                   string name, 
                                   string type, 
                                   string timestamp)
        {
            string sql = "INSERT INTO device(" +
                "id,name,type,timestamp) VALUES (" +
                             "'" + id + "'," +
                             "'" + name + "'," +
                             "'" + type + "'," +
                             "'" + timestamp + "');";

            return sql;
        }
    }
}
