using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

using qcloudsms_csharp;
using qcloudsms_csharp.json;
using qcloudsms_csharp.httpclient;

using AllHomeNode.Help;


namespace AllHomeNode.Service.SMS
{
    public class Service_SMS
    {
        private static Service_SMS _instance = null;
        private Configuration_SMS _configuration = null;

        private Hashtable _queue = null;
        private Thread _thread = null;
        private bool bStopServiec = false;

        private Service_SMS()
        {

        }

        public static Service_SMS Instance()
        {
            if (_instance == null)
            {
                _instance = new Service_SMS();
            }

            return _instance;
        }

        public void InitializeService(Configuration_SMS config)
        {
            _configuration = config;
            _queue = Hashtable.Synchronized(new Hashtable());
            _thread = new Thread(new ThreadStart(Run));
        }

        public void ServiceStart()
        {
            if (_thread != null)
                _thread.Start();
        }

        public void ServiceStop()
        {
            bStopServiec = true;
        }

        public Message_SMS SendRandomCode(string mobile)
        {
            Message_SMS msg = new Message_SMS();
            msg.Mobile = mobile;
            Random rad = new Random();              //实例化随机数产生器rad；
            int value = rad.Next(1000, 10000);      //用rad生成大于等于1000，小于等于9999的随机数；
            msg.RandomCode = value.ToString();
            msg.LifeTime = 10;
            msg.TimeStamp = DateTime.Now;
            msg.Send = false;

            if (_queue.ContainsKey(mobile))
                _queue.Remove(mobile);
            _queue.Add(mobile, msg);
            
            return msg;
        }

        public bool CheckRandomCode(string mobile, string randomCode)
        {
            if(_queue.ContainsKey(mobile))
            {
                Message_SMS msg = _queue[mobile] as Message_SMS;
                DateTime now = DateTime.Now;
                TimeSpan timeSpan = now - msg.TimeStamp;
                if (msg.RandomCode.Equals(randomCode) && timeSpan.TotalMinutes <= msg.LifeTime)
                {
                    _queue.Remove(mobile);
                    return true;
                }
                else
                {
                    _queue.Remove(mobile);
                    return false;
                }
            }

            return false;
        }

        private void Run()
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;

            while (!bStopServiec)
            {
                foreach(string key in _queue.Keys)
                {
                    Message_SMS msg = _queue[key] as Message_SMS;
                    if(msg.Send == false)
                    {
                        try
                        {
                            SmsSingleSender ssender = new SmsSingleSender(_configuration.AppId, _configuration.AppKey);
                            var result = ssender.sendWithParam("86",
                                msg.Mobile,
                                _configuration.TemplateId,
                                new[] { msg.RandomCode, msg.LifeTime.ToString() },
                                _configuration.SignatureName,
                                "",
                                "");

                            msg.Send = true;

                            LogHelper.WriteLog(LogLevel.Warn,
                                t,
                                "发送短信：" +
                                msg.Mobile +
                                " 验证码 " +
                                msg.RandomCode);
                        }
                        catch (JSONException e)
                        {
                            LogHelper.WriteLog(LogLevel.Error, t, e);
                        }
                        catch (HTTPException e)
                        {
                            LogHelper.WriteLog(LogLevel.Error, t, e);
                        }
                        catch (Exception e)
                        {
                            LogHelper.WriteLog(LogLevel.Error, t, e);
                        }
                    }
                }

                Thread.Sleep(100);
            }
        }
    }
}
