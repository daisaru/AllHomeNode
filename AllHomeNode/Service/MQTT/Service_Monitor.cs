using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using AllHomeNode.Front;
using AllHomeNode.Help;
using AllHomeNode.Repository;
using AllHomeNode.Service.MQTT.Device;
using uPLibrary.Networking.M2Mqtt.Messages;
using static AllHomeNode.Service.MQTT.Enums;

namespace AllHomeNode.Service.MQTT
{
    public class Service_Monitor
    {
        private static Service_Monitor _instance = null;

        private Timer _timeSyncTimer = null;

        private ConcurrentQueue<Message> _qSend = new ConcurrentQueue<Message>();
        public ConcurrentQueue<Message> QSend
        {
            get { return _qSend; }
            set { _qSend = value; }
        }
        private AutoResetEvent _sendQEvent = new AutoResetEvent(false);
        public AutoResetEvent SendQEvent
        {
            get { return _sendQEvent; }
            set { _sendQEvent = value; }
        }

        private Thread _workerThread = null;

        private MQTT _mqttInstance = null;

        public void StartService(Configuration_MQTT configMQTT)
        {
            _mqttInstance = MQTT.Instance();
            _mqttInstance.Connect(configMQTT.ClientID,
                configMQTT.BrokerURL,
                configMQTT.Port,
                configMQTT.Username,
                configMQTT.Password,
                MQTT_Received);
            _mqttInstance.Subscribe(configMQTT.ReceiveTopic);

            _workerThread = new Thread(new ThreadStart(Run));
            _workerThread.Start();

            _timeSyncTimer = new Timer(new TimerCallback(TimerUp), null, 0, 60*10*1000);
        }

        // 发送心跳包
        private void TimerUp(object value)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, "HEART BEAT");
            CommandDownload cmd = CommandHelper.Instance().GetTimeSyncCommand();
            string cmdStr = cmd.ToJSON();
            MQTT_Send("to/device/timesync", cmdStr);
        }

        private void MQTT_Send(string topic, string data)
        {
            byte[] buf = ASCIIEncoding.ASCII.GetBytes(data);
            _mqttInstance.Publish(topic, buf);
        }

        private void MQTT_Received(object sender, MqttMsgPublishEventArgs e)
        {
            string msgStr = ASCIIEncoding.ASCII.GetString(e.Message);

            try
            {
                CommandUpload rsp = JsonHelper.FromJSON<CommandUpload>(msgStr);

                Message msg = new Message();
                msg.id = Guid.NewGuid().ToString();
                msg.topic = e.Topic;
                msg.cmdUpload = rsp;
                _qSend.Enqueue(msg);
                if (_qSend.Count >= 1)
                {
                    _sendQEvent.Set();
                }
            }
            catch(Exception exp)
            {
                Type t = MethodBase.GetCurrentMethod().DeclaringType;
                LogHelper.WriteLog(LogLevel.Error, t, exp);
            }
        }

        private void Run()
        {
            while (true)
            {
                try
                {
                    if (_qSend.Count <= 0)
                    {
                        _sendQEvent.WaitOne();
                    }

                    Message msg = null;
                    bool ret = _qSend.TryDequeue(out msg);

                    if(ret == true)
                    {
                        ProcessMsg(msg);
                    }
                }
                catch(Exception exp)
                {
                    Console.WriteLine(exp.Message);
                    Type t = MethodBase.GetCurrentMethod().DeclaringType;
                    LogHelper.WriteLog(LogLevel.Error, t, exp);
                }

                Thread.Sleep(10);
            }
        }

        private void ProcessMsg(Message msg)
        {
            CommandUpload cmd = msg.cmdUpload;
            switch(cmd.Code)
            {
                case FIXEDCONTROLPOINTS.TIMESYNC:
                    {
                        string[] data = msg.cmdUpload.Value.Split(new char[] { ' ' });
                        HeartbeatData hbData = new HeartbeatData();
                        hbData.GatewayId = data[0];
                        hbData.SoftwareVersion = data[1];
                        hbData.HardwareVersion = "";
                        hbData.GatewayTime = DateTime.Parse(msg.cmdUpload.TimeStamp);
                        hbData.TimeStamp = DateTime.Now;

                        GatewayRepository repository = new GatewayRepository();
                        repository.AddHeartBeat(hbData);

                        break;
                    }
                default:
                    {
                        CommandUpload cmdUpload = msg.cmdUpload;
                        string code = cmdUpload.Code;
                        string data = cmdUpload.Data;

                        GatewayRepository repository = new GatewayRepository();
                        ControlPointData cpData = repository.GetControlPointByCode(code);
                        DEVICETYPE deviceType = (DEVICETYPE)Enum.Parse(typeof(DEVICETYPE), cpData.Type, true);

                        DataRepository dataRepo = new DataRepository();

                        if(deviceType == DEVICETYPE.VENT)
                        {
                            VENT_EAWADA eawadaObj = JsonHelper.FromJSON<VENT_EAWADA>(data);
                            if(eawadaObj != null)
                            {
                                Type t = MethodBase.GetCurrentMethod().DeclaringType;
                                LogHelper.WriteLog(LogLevel.Warn, t, "AIR DATA FROM " + eawadaObj.DeviceId);

                                bool ret = dataRepo.AddAirData(eawadaObj);
                            }
                        }
                        else if(deviceType == DEVICETYPE.POWER)
                        {
                            SWITCH_JSY jsyObj = JsonHelper.FromJSON<SWITCH_JSY>(data);
                            if(jsyObj != null)
                            {
                                Type t = MethodBase.GetCurrentMethod().DeclaringType;
                                LogHelper.WriteLog(LogLevel.Warn, t, "POWER DATA FROM " + jsyObj.DeviceId);

                                bool ret = dataRepo.AddPowerData(jsyObj, code);
                            }
                        }
                        break;
                    }
            }
        }

        private Service_Monitor()
        {

        }

        public static Service_Monitor Instance()
        {
            if(_instance == null)
            {
                _instance = new Service_Monitor();
            }

            return _instance;
        }
    }
}
