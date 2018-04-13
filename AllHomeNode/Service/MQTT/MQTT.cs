using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using static uPLibrary.Networking.M2Mqtt.MqttClient;

namespace AllHomeNode.Service.MQTT
{
    public class MQTT
    {
        private static MQTT _instance = null;

        private MqttClient _mqttClient = null;

        private string _strClientID = "";
        private string _strHostName = "";
        private int _iPort = 1883;
        private string _strUserName = "admin";
        private string _strPassword = "password";

        private MqttMsgPublishEventHandler _handlerReceive = null;

        private MQTT()
        {

        }

        public static MQTT Instance()
        {
            if (_instance == null)
            {
                _instance = new MQTT();
            }
            return _instance;
        }

        internal void Disconnect()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Connect to MQTT Broker
        /// </summary>
        /// <param name="ClientID"></param>
        /// <param name="HostName"></param>
        /// <param name="Port"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="ReceiveHandler"></param>
        /// <returns>0x00 Connection Accepted</returns>
        /// <returns>0x01 Connection Refused:unaccepted protocol version</returns>
        /// <returns>0x02 Connection Refused:identifier rejected</returns>
        /// <returns>0x03 Connection Refused:server unavailable</returns>
        /// <returns>0x04 Connection Refused:bad user name or password</returns>
        /// <returns>0x05 Connection Refused: not authorized</returns>
        public int Connect(string ClientID, string HostName, int Port, string UserName, string Password, MqttMsgPublishEventHandler ReceiveHandler)
        {
            int ret = 0;

            _strClientID = ClientID;
            _strHostName = HostName;
            _iPort = Port;
            _strUserName = UserName;
            _strPassword = Password;
            _handlerReceive = ReceiveHandler;

            // create client instance 
            _mqttClient = new MqttClient(_strHostName, _iPort, false, null, null, MqttSslProtocols.None);
            // register to message received 
            _mqttClient.MqttMsgPublishReceived += _handlerReceive;

            ret = _mqttClient.Connect(_strClientID, _strUserName, _strPassword, true, 120);

            return ret;
        }

        public void Disconnect(ConnectionClosedEventHandler CloseHandler)
        {
            if (_mqttClient != null && _mqttClient.IsConnected)
            {
                _mqttClient.ConnectionClosed += CloseHandler;
                _mqttClient.Disconnect();
            }
        }

        public int Subscribe(string Topic)
        {
            // subscribe to the topic with QoS 2 
            int subid = -1;
            if (_mqttClient != null)
            {
                subid = _mqttClient.Subscribe(new string[] { Topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            }
            return subid;
        }

        public int UnSubscribe(string Topic)
        {
            int subid = -1;
            if (_mqttClient != null)
            {
                subid = _mqttClient.Unsubscribe(new string[] { Topic });
            }
            return subid;
        }

        public int Publish(string Topic, byte[] Message)
        {
            // publish a message on topic with QoS 2 
            int ret = -1;
            if (_mqttClient != null && _mqttClient.IsConnected)
            {
                ret = _mqttClient.Publish(Topic, Message, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            }
            return ret;
        }
    }
}
