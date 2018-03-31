using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Microsoft.Owin.Hosting;
using AllHomeNode.Database;
using AllHomeNode.Database.Manager;
using AllHomeNode.Help;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AllHomeNode
{
    class Program
    {
        static void Main(string[] args)
        {
            LogHelper.WriteLog("MAIN", "AllHome Node is Starting...");
            // DB Test
            //MySqlConnection conn = MySQLHelper.DBConnect();
            //DataSet data = MySQLHelper.GetDataSet(MySQLHelper.Conn,
            //                                        System.Data.CommandType.Text,
            //                                        "select * from tb_user",
            //                                        null);
            //Console.ReadLine();

            string baseAddress = "http://localhost:9000/";

            // NHibernate Test
            //UserManager userManager = new UserManager();
            //IList<User> users = userManager.GetUserList();
            //Console.ReadLine();

            // Start OWIN host   
            WebApp.Start<StartUp>(url: baseAddress);

            //Create HttpCient and make a request to api/ user
            //HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseAddress + "api/user").Result;
            //Console.WriteLine(response);
            //Console.WriteLine(response.Content.ReadAsStringAsync().Result);


            Console.ReadLine();
        }
    }
}
