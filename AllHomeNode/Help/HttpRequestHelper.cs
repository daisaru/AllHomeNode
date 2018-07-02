using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO.Compression;
using System.Text.RegularExpressions;

using AllHomeNode.Data.Weather;
using AllHomeNode.Data.Air;

namespace AllHomeNode.Help
{
    public class HttpHelper
    {
        private static HttpHelper _instance = null;

        private const string _strGetNowWeatherUrl = "https://api.heweather.com/s6/weather/now?";
        private const string _strGetNowAirUrl = "https://api.heweather.com/s6/air/now?";

        private const string _strServiceKey = "aa5ec1ffa80c4057875779191b0b208c";

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

        public Weather GetNowWeather(string cityName)
        {
            Weather ret = null;

            string strRequest = _strGetNowWeatherUrl + "location=" + cityName + "&key=" + _strServiceKey;

            string retStr = SendRequest("", strRequest);
            ret = JsonHelper.FromJSON<Weather>(retStr);

            return ret;
        }

        public Air GetNowAir(string cityName)
        {
            Air ret = null;

            string strRequest = _strGetNowAirUrl + "location=" + cityName + "&key=" + _strServiceKey;

            string retStr = SendRequest("", strRequest);
            ret = JsonHelper.FromJSON<Air>(retStr);

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