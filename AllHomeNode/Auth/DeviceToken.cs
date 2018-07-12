using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AllHomeNode.Help;

namespace AllHomeNode.Auth
{
    public class GatewayToken
    {
        private Hashtable _deviceTokens = null;
        private static GatewayToken _instance = null;
        
        private GatewayToken()
        {
            _deviceTokens = new Hashtable();
        }

        public static GatewayToken Intance()
        {
            if (_instance == null)
                _instance = new GatewayToken();
            return _instance;
        }

        public Token GetandRefreshToken(string mobile, string deviceId)
        {
            string key = mobile + deviceId;
            if (_deviceTokens.ContainsKey(key))
            {
                Token updateToken = (Token)_deviceTokens[key];
                updateToken.StartTime = DateTime.Now; // 开始时间
                updateToken.TokenString = SecurityHelper.Instance().GetServiceToken(key + updateToken.StartTime);   // 按一定规则生成Token字符串
                updateToken.TokenLife = 60;           // 分钟
                return updateToken;
            }
            else
            {
                Token token = new Token();
                token.StartTime = DateTime.Now; // 开始时间
                token.TokenString = SecurityHelper.Instance().GetServiceToken(key + token.StartTime);          // 按一定规则生成Token字符串
                token.TokenLife = 60;           // 分钟
                _deviceTokens.Add(key, token);
                return token;
            }
        }

        public bool isTokenValid(string mobile, string deviceId, string token)
        {
            string key = mobile + deviceId;
            if (_deviceTokens.ContainsKey(key) == false)
            {
                return false;
            }

            return true;
        }
    }
}
