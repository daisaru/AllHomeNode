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

using InstallationTool.Front;
using Newtonsoft.Json;

namespace AllHomeDBConfig
{
    public class HttpHelper
    {
        private static HttpHelper _instance = null;

        private const string _strRegisterGatewayUrl = "http://115.159.78.40:9000/api/gateway/registerdevice";
        private const string _strUoloadControlPointsUrl = "http://115.159.78.40:9000/api/gateway/uploadcontrolpoints";
        private const string _strLoginUrl = "http://115.159.78.40:9000/api/user/login";
        private const string _strUninstallAllDevices = "http://115.159.78.40:9000/api/gateway/uninstallalldevice";
        private const string _strUninstallDevice = "http://115.159.78.40:9000/api/gateway/uninstalldevice";
        private const string _strGetAllGateway = "http://115.159.78.40:9000/api/gateway/fetchallgateway";
        private const string _strGetAllControlpoints = "http://115.159.78.40:9000/api/gateway/fetchcontrolpoints";

        private const string _strRegisterGatewayUrl_test = "http://localhost:9000/api/device/registerdevice";
        private const string _strUoloadControlPointsUrl_test = "http://localhost:9000/api/device/uploadcontrolpoints";
        private const string _strLoginUrl_test = "http://localhost:9000/api/user/login";
        private const string _strUninstallAllDevices_test = "http://localhost:9000/api/gateway/uninstallalldevice";
        private const string _strUninstallDevice_test = "http://localhost:9000/api/gateway/uninstalldevice";
        private const string _strGetAllGateway_test = "http://localhost:9000/api/gateway/fetchallgateway";
        private const string _strGetAllControlpoints_test = "http://localhost:9000/api/gateway/fetchcontrolpoints";

        private string _strLoginToken = "";

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

        public GetControlPointsRspData GetAllControlPoints(string mobile, string gatewayid)
        {
            GetControlPointsRspData ret = null;

            GetControlPointsReqData data = new GetControlPointsReqData();
            data.GatewayId = gatewayid;
            data.Mobile = mobile;
            data.Token = _strLoginToken;

            string jsonData = JsonConvert.SerializeObject(data);
            string retStr = SendRequest(jsonData, _strGetAllControlpoints);

            ret = JsonConvert.DeserializeObject<GetControlPointsRspData>(retStr);

            return ret;
        }

        public GetAllGatewayRspData GetAllGateways(string mobile)
        {
            GetAllGatewayRspData ret = null;

            GetAllGatewayReqData data = new GetAllGatewayReqData();
            data.Mobile = mobile;
            data.Token = _strLoginToken;

            string jsonData = JsonConvert.SerializeObject(data);
            string retStr = SendRequest(jsonData, _strGetAllGateway);

            ret = JsonConvert.DeserializeObject<GetAllGatewayRspData>(retStr);

            return ret;
        }

        public DeleteAllDeviceRspData DeleteAllDevices(string mobile, string gatewayid)
        {
            DeleteAllDeviceRspData ret = null;

            DeleteAllDeviceReqData data = new DeleteAllDeviceReqData();
            data.GatewayId = gatewayid;
            data.Mobile = mobile;
            data.Token = _strLoginToken;

            string jsonData = JsonConvert.SerializeObject(data);
            string retStr = SendRequest(jsonData, _strUninstallAllDevices);

            ret = JsonConvert.DeserializeObject<DeleteAllDeviceRspData>(retStr);

            return ret;
        }

        public DeleteDeviceRspData DeleteDevice(string mobile, string gatewayid, string deviceid)
        {
            DeleteDeviceRspData ret = null;

            DeleteDeviceReqData data = new DeleteDeviceReqData();
            data.Mobile = mobile;
            data.GatewayId = gatewayid;
            data.DeviceId = deviceid;
            data.Token = _strLoginToken;

            string jsonData = JsonConvert.SerializeObject(data);
            string retStr = SendRequest(jsonData, _strUninstallDevice);

            ret = JsonConvert.DeserializeObject<DeleteDeviceRspData>(retStr);

            return ret;
        }

        public LoginRspData UserLogin(string username, string password)
        {
            LoginRspData ret = null;

            LoginReqData data = new LoginReqData();
            data.Mobile = username;
            data.Password = password;
            data.OldToken = "";

            string jsonData = JsonConvert.SerializeObject(data);
            string retStr = SendRequest(jsonData, _strLoginUrl);

            ret = JsonConvert.DeserializeObject<LoginRspData>(retStr);

            _strLoginToken = ret.Token;

            return ret;
        }

        public GatewayRegisterRspData RegisterGateway(string id, string name, string signature)
        {
            GatewayRegisterRspData ret = null;

            GatewayRegisterReqData data = new GatewayRegisterReqData();
            data.GatewayId = id;
            data.GatewayName = name;
            data.Signature = signature;

            string jsonData = JsonConvert.SerializeObject(data);
            string retStr = SendRequest(jsonData, _strRegisterGatewayUrl);

            ret = JsonConvert.DeserializeObject<GatewayRegisterRspData>(retStr);

            return ret;
        }

        public GatewayUploadCtrlPointsRspData UploadControllPoints(string id, List<DeviceData> deviceData, string signature)
        {
            GatewayUploadCtrlPointsRspData ret = null;

            GatewayUploadCtrlPointsReqData data = new GatewayUploadCtrlPointsReqData();
            data.GatewayId = id;
            data.Signature = signature;
            data.Device = deviceData;

            string jsonData = JsonConvert.SerializeObject(data);
            string retStr = SendRequest(jsonData, _strUoloadControlPointsUrl);

            ret = JsonConvert.DeserializeObject<GatewayUploadCtrlPointsRspData>(retStr);

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