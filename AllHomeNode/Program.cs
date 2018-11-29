using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Runtime.InteropServices;

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
        #region Win32DLL引入
        [DllImport("User32.dll ", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll ", EntryPoint = "GetSystemMenu")]
        extern static IntPtr GetSystemMenu(IntPtr hWnd, IntPtr bRevert);
        [DllImport("user32.dll ", EntryPoint = "RemoveMenu")]
        extern static int RemoveMenu(IntPtr hMenu, int nPos, int flags);
        #endregion

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

                //string baseAddress = "http://localhost:9000/";                // Local Machine
                //string baseAddress = "http://10.105.214.156:9000/";             // 腾讯云，测试环境
                string baseAddress = "https://172.17.0.5:9000/";               // 腾讯云，生产环境

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
                
                //测试环境
                //_configSMS.AppId = 1400082480;
                //_configSMS.AppKey = "d40aaca2c8bb41b607ad33b3bc7a63ff";
                //_configSMS.TemplateId = 106928;
                //_configSMS.SignatureName = "大猿实验室";
                //生产环境
                _configSMS.AppId = 1400147314;
                _configSMS.AppKey = "fa4401b5d1f7afce64d0cb1e9647e473";
                _configSMS.TemplateId = 206320;
                _configSMS.SignatureName = "全屋集成建筑技术有限公司";

                Service_SMS smsService = Service_SMS.Instance();
                smsService.InitializeService(_configSMS);
                smsService.ServiceStart();
                #endregion

                // Start MQTT Service
                #region
                Configuration_MQTT _configMQTT = new Configuration_MQTT();
                //_configMQTT.BrokerURL = "115.159.78.40";      // 测试环境
                _configMQTT.BrokerURL = "115.159.72.249";       // 生产环境
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

            //与控制台标题名一样的路径
            string fullPath = System.Environment.CurrentDirectory + "\\AllHomeNode.exe";
            //根据控制台标题找控制台
            int WINDOW_HANDLER = FindWindow(null, fullPath);
            //找关闭按钮
            IntPtr CLOSE_MENU = GetSystemMenu((IntPtr)WINDOW_HANDLER, IntPtr.Zero);
            int SC_CLOSE = 0xF060;
            //关闭按钮禁用
            RemoveMenu(CLOSE_MENU, SC_CLOSE, 0x0);

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
