using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AllHomeNode.Help;

namespace AllHomeNode.Auth
{
    public class ServiceToken
    {
        private Hashtable _serviceTokens = null;
        private static ServiceToken _instance = null;
        
        private ServiceToken()
        {
            _serviceTokens = new Hashtable();
        }

        public static ServiceToken Intance()
        {
            if (_instance == null)
                _instance = new ServiceToken();
            return _instance;
        }

        public Token GetandRefreshToken(string key)
        {
            if (_serviceTokens.ContainsKey(key))
            {
                Token updateToken = (Token)_serviceTokens[key];
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
                _serviceTokens.Add(key, token);
                return token;
            }
        }

        public bool isTokenValid(string key, string token)
        {
            if(_serviceTokens.ContainsKey(key) == false)
            {
                return false;
            }

            return true;
        }
    }
}
