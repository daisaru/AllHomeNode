using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllHomeDBConfig
{
    public class Controlpoint
    {
        public static string GetSelectSQL()
        {
            string sql = "SELECT id_device," +
                                "code," +
                                "type," +
                                "subtype," +
                                "givenname," +
                                "brand," +
                                "model," +
                                "point," +
                                "channel," +
                                "address," +
                                "registergroup," +
                                "register," +
                                "timestamp," +
                                "summary " +
                                "FROM controlpoint;";
            return sql;
        }

        public static string GetInsertSQL(string deviceId, 
                                   string code, 
                                   string type, 
                                   string subtype, 
                                   string givenname, 
                                   string brand, 
                                   string model, 
                                   string point,
                                   string channel,
                                   string address,
                                   string registergroup,
                                   string register,
                                   string timestamp,
                                   string summary)
        {
            string sql = "INSERT INTO controlpoint(" +
                "id_device,code,type,subtype,givenname,brand,model,point," +
                "channel,address,registergroup,register,timestamp,summary) VALUES (" +
                             "'" + deviceId + "'," +
                             "'" + code + "'," +
                             "'" + type + "'," +
                             "'" + subtype + "'," +
                             "'" + givenname + "'," +
                             "'" + brand + "'," +
                             "'" + model + "'," +
                             "'" + point + "'," +
                             "'" + channel + "'," +
                             "'" + address + "'," +
                             "'" + registergroup + "'," +
                             "'" + register + "'," +
                             "'" + timestamp + "'," +
                             "'" + summary + "');";

            return sql;
        }
    }
}
