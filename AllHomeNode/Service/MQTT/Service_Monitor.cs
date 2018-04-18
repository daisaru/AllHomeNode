using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using AllHomeNode.Help;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace AllHomeNode.Service.MQTT
{
    public class Service_Monitor
    {
        private static Service_Monitor _instance = null;

        private Timer _timeSyncTimer = null;

        private Queue<Message> _qSend = new Queue<Message>();
        private Queue<Message> QSend
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

            _timeSyncTimer = new Timer(new TimerCallback(TimerUp), null, 0, 60000);
        }

        // 发送心跳包
        private void TimerUp(object value)
        {
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

        private void Run()
        {
            while (true)
            {
                if (_qSend.Count <= 0)
                {
                    _sendQEvent.WaitOne();
                }

                Message msg = _qSend.Dequeue();

                ProcessMsg(msg);

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
                        Console.WriteLine(msg.cmdReq.Value);
                        break;
                    }
                default:
                    {
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
