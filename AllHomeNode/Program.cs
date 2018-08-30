using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.Threading;

using Microsoft.Owin.Hosting;
using MySql.Data;
using MySql.Data.MySqlClient;
using AllHomeNode.Help;
using AllHomeNode.Database;
using AllHomeNode.Database.Manager;
using AllHomeNode.Service.SMS;
using AllHomeNode.Service.MQTT;
using AllHomeNode.Service.Quartz;
using AllHomeNode.Service.MQTT.Device;
using AllHomeNode.Repository;
using AllHomeNode.Auth;

namespace AllHomeNode
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;

            try
            {
                LogHelper.WriteLog(LogLevel.Warn, t, "AllHome Node is Starting...");

                // Power Monthly Summary Test
                //QuartzTask_SummaryPowerData.SummaryMonthlyPower();

                // Random code test
                //string code = RandomCodeUtility.MakeCode(4);
                //string codepic = RandomCodeUtility.CreateRandomCode(code);


                // Weather & Air Test
                //VENT_EAWADA eawada = new VENT_EAWADA();
                //eawada.DeviceId = "12345678";
                //DataRepository dataRepository = new DataRepository();
                //dataRepository.AddAirData(eawada);

                // DB Test
                //MySqlConnection conn = MySQLHelper.DBConnect();
                //DataSet data = MySQLHelper.GetDataSet(MySQLHelper.Conn,
                //                                        System.Data.CommandType.Text,
                //                                        "select * from tb_user",
                //                                        null);
                //Console.ReadLine();

                //string baseAddress = "http://localhost:9000/";              // Local Machine
                string baseAddress = "http://10.105.214.156:9000/";               // Tencent
                //string baseAddress = "http://192.168.3.10:9000/";             // Local Network

                // NHibernate Test
                //UserManager userManager = new UserManager();
                //IList<User> users = userManager.GetUserList();
                //Console.ReadLine();

                // Start Quarz Service
                #region
                Service_Quartz quartzService = Service_Quartz.Instance();
                quartzService.StartTimer();
                #endregion

                // Start OWIN host   
                WebApp.Start<StartUp>(url: baseAddress);
                LogHelper.WriteLog(LogLevel.Warn, t, "OWIN Selfhost is started.");

                // Start SMS Service
                #region
                Configuration_SMS _configSMS = new Configuration_SMS();
                _configSMS.AppId = 1400082480;
                _configSMS.AppKey = "d40aaca2c8bb41b607ad33b3bc7a63ff";
                _configSMS.TemplateId = 106928;
                _configSMS.SignatureName = "大猿实验室";
                Service_SMS smsService = Service_SMS.Instance();
                smsService.InitializeService(_configSMS);
                smsService.ServiceStart();
                #endregion

                // Start MQTT Service
                #region
                Configuration_MQTT _configMQTT = new Configuration_MQTT();
                _configMQTT.BrokerURL = "115.159.78.40";
                _configMQTT.Port = 1883;
                _configMQTT.Username = "admin";
                _configMQTT.Password = "admin";
                _configMQTT.ClientID = "AllHomeNodeServer";
                _configMQTT.ReceiveTopic = "from/device/service/#";
                Service_Monitor monitorService = Service_Monitor.Instance();
                monitorService.StartService(_configMQTT);
                #endregion

                //Create HttpCient and make a request to api/ user
                //HttpClient client = new HttpClient();
                //var response = client.GetAsync(baseAddress + "api/user").Result;
                //Console.WriteLine(response);
                //Console.WriteLine(response.Content.ReadAsStringAsync().Result);

            }
            catch (Exception startExp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, startExp);
            }

            string ctrlCmd = "";
            do
            {
                Console.Write(">");
                ctrlCmd = Console.ReadLine();
                Thread.Sleep(100);
            }
            while (ctrlCmd.Equals("Exit") != true);

        }
 
    }
}
