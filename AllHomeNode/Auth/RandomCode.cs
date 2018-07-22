using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AllHomeNode.Auth
{
    public class RandomCode
    {
        public static RandomCode _instance = null;
        private Hashtable _randomCodes = null;

        private Timer _tokenTimer = null;

        private RandomCode()
        {
            _randomCodes = new Hashtable();
            _tokenTimer = new Timer(90*1000);
            _tokenTimer.Elapsed += _randomCodeTimer_Elapsed;
            _tokenTimer.Start();
        }

        ~RandomCode()
        {
            _tokenTimer.Stop();
        }

        private void _randomCodeTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            List<string> delKeys = new List<string>();
            foreach (string key in _randomCodes.Keys)
            {
                RandomCodeEntity t = _randomCodes[key] as RandomCodeEntity;
                DateTime endTime = t.StartTime.AddMinutes(t.CodeLife);
                if (endTime <= DateTime.Now)
                {
                    delKeys.Add(key);
                }
            }

            foreach (string delKey in delKeys)
            {
                _randomCodes.Remove(delKey);
            }
        }

        public static RandomCode Instance()
        {
            if(_instance == null)
            {
                _instance = new RandomCode();
            }
            return _instance;
        }

        public bool isRandomCodeValid(string key, string code)
        {
            if (_randomCodes.ContainsKey(key) == false)
            {
                return false;
            }

            return true;
        }

        public RandomCodeEntity GetRandomCode(string key)
        {
            RandomCodeEntity retObj = null;
            
            if (_randomCodes.ContainsKey(key) == false)
            { 
                retObj = new RandomCodeEntity();
                retObj.StartTime = DateTime.Now; // 开始时间
                retObj.CodeString = RandomCodeUtility.MakeCode(4);
                retObj.CodePicBase64 = RandomCodeUtility.CreateRandomCode(retObj.CodeString);
                retObj.CodeLife = 2;             // 分钟
                _randomCodes.Add(key, retObj);
                return retObj;
            }
            else
            {
                retObj = _randomCodes[key] as RandomCodeEntity;
            }

            return retObj;
        }
    }
}
