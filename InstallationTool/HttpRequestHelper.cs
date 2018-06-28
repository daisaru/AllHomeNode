using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;

namespace InstallationTool
{
    using InstallationTool.Front;
    using Newtonsoft.Json;
    using System.IO;
    using System.Net;
    using System.Text;

    public class HttpHelper
    {
        private static HttpHelper _instance = null;

        private const string _strRegisterGatewayUrl = "http://115.159.78.40:9000/api/device/registerdevice";
        private const string _strUoloadControlPointsUrl = "http://115.159.78.40:9000/api/device/uploadcontrolpoints";

        private const string _strRegisterGatewayUrl_test = "http://localhost:9000/api/device/registerdevice";
        private const string _strUoloadControlPointsUrl_test = "http://localhost:9000/api/device/uploadcontrolpoints";

        private HttpHelper()
        {
        }

        public static HttpHelper Instance()
        {
            if(_instance == null)
            {
                _instance = new HttpHelper();
            }
            return _instance;
        }

        public GatewayRegisterRspData RegisterGateway(string id, string name, string signature)
        {
            GatewayRegisterRspData ret = null;

            GatewayRegisterReqData data = new GatewayRegisterReqData();
            data.DeviceId = id;
            data.DeviceName = name;
            data.Signature = signature;

            string jsonData = JsonConvert.SerializeObject(data);
            string retStr = SendRequest(jsonData, _strRegisterGatewayUrl);

            GatewayRegisterRspData retData = JsonConvert.DeserializeObject<GatewayRegisterRspData>(retStr);

            return ret;
        }

        public string UploadControllPoints(string id, List<RoomData> roomdatas, string signature)
        {
            string ret = "";

            GatewayUploadCtrlPointsReqData data = new GatewayUploadCtrlPointsReqData();
            data.DeviceId = id;
            data.Signature = signature;
            data.Rooms = roomdatas;

            string jsonData = JsonConvert.SerializeObject(data);
            ret = SendRequest(jsonData, _strUoloadControlPointsUrl);

            return ret;
        }

        private string SendRequest(string data, string requestUrl)
        {
            return SendRequest(Encoding.GetEncoding("UTF-8").GetBytes(data), requestUrl);
        }

        private string SendRequest(byte[] data, string requestUrl)
        {
            string htmlStr = string.Empty;

            //创建一个客户端的Http请求实例
            HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = "POST";
            request.ContentLength = data.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();

            //获取当前Http请求的响应实例
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream responseStream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("UTF-8")))
            {
                htmlStr = reader.ReadToEnd();
            }
            responseStream.Close();

            return htmlStr;
        }
    }
}