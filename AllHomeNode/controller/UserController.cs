using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Reflection;

using AllHomeNode.Front;
using AllHomeNode.Repository;
using AllHomeNode.Auth;
using AllHomeNode.Help;
using AllHomeNode.Service.SMS;

namespace AllHomeNode.controller
{
    public class UserController : ApiController
    {
        private UserRepository repository = new UserRepository();

        public LogHelper Log { get; set; }

        // GET /api/user
        public IEnumerable<UserData> GetAllUsers()
        {
            //return repository.GetAll();
            return null;
        }

        // 获取用户信息
        // POST /api/user/fetchuserinfo
        public GetUserInfoRspData FetchUserInfo([FromBody]GetUserInfoReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            GetUserInfoRspData ret = new GetUserInfoRspData();

            bool checkToken = ServiceToken.Intance().isTokenValid(item.Mobile, item.Token);
            if(checkToken == false)
            {
                LogHelper.WriteLog(LogLevel.Error, t, "Token Invalid");

                ret.Result = CommandUtil.RETURN.ERROR_TOKEN_INVALID;
                ret.User = null;
                return ret;
            }

            try
            {
                UserData data = repository
                                .GetAll()
                                .Where(r => string.Equals(r.Mobile, item.Mobile))
                                .Select(r => r).ToList()[0];
                data.Password = "";
                data.RandomCode = "";

                ret.Result = CommandUtil.RETURN.SUCCESS;
                ret.User = data;
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                ret.User = null;
                return ret;
            }

            return ret;
        }

        // 注册用户
        // POST api/user/register
        public ReturnResult Register([FromBody]UserData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);
            
            ReturnResult ret = new ReturnResult();

            bool checkRandomCode = Service_SMS.Instance().CheckRandomCode(item.Mobile, item.RandomCode);
            if (checkRandomCode == false)
            {
                LogHelper.WriteLog(LogLevel.Error, t, "RandomCode Invalid");

                ret.Result = CommandUtil.RETURN.ERROR_RANDOMCODE_INVALID;
                return ret;
            }

            try
            {
                UserData user = repository.Add(item);

                if (user != null)
                {
                    ret.Result = CommandUtil.RETURN.SUCCESS;
                }
                else
                {
                    ret.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                }
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                return ret;
            }

            return ret;
        }

        // 修改用户信息
        // POST api/user/update
        public ReturnResult Update([FromBody]UserData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            ReturnResult ret = new ReturnResult();
            
            bool checkRandomCode = Service_SMS.Instance().CheckRandomCode(item.Mobile, item.RandomCode);
            if (checkRandomCode == false)
            {
                LogHelper.WriteLog(LogLevel.Error, t, "RandomCode Invalid");

                ret.Result = CommandUtil.RETURN.ERROR_RANDOMCODE_INVALID;
                return ret;
            }

            try
            {
                bool success = repository.Update(item);

                if (success)
                {
                    ret.Result = CommandUtil.RETURN.SUCCESS;
                }
                else
                {
                    ret.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                }
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                return ret;
            }

            return ret;
        }

        // 用户登陆
        // POST api/user/login
        public ReturnResult Login([FromBody]LoginReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            LoginRspData rsp = new LoginRspData();

            try
            {
                bool ret = repository.Login(item.Mobile, item.Password);

                if (ret)
                {
                    Token token = ServiceToken.Intance().GetandRefreshToken(item.Mobile);
                    rsp.Result = CommandUtil.RETURN.SUCCESS;
                    rsp.Token = token.TokenString;
                    rsp.TimeStamp = token.StartTime.ToString();
                    rsp.TokenLife = token.TokenLife.ToString();
                }
                else
                {
                    rsp.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                    rsp.Token = "";
                    rsp.TimeStamp = "";
                    rsp.TokenLife = "";
                }
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                rsp.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                rsp.Token = "";
                rsp.TimeStamp = "";
                rsp.TokenLife = "";
                return rsp;
            }

            return rsp;
        }

        // 重置密码
        // POST api/user/resetpassword
        public ReturnResult ResetPassword([FromBody] ResetPasswordReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            ReturnResult rsp = new ReturnResult();

            bool checkToken = ServiceToken.Intance().isTokenValid(item.Mobile, item.Token);
            if (checkToken == false)
            {
                LogHelper.WriteLog(LogLevel.Error, t, "Token Invalid");

                rsp.Result = CommandUtil.RETURN.ERROR_TOKEN_INVALID;
                return rsp;
            }

            bool checkRandomCode = Service_SMS.Instance().CheckRandomCode(item.Mobile, item.RandomCode);
            if (checkRandomCode == false)
            {
                LogHelper.WriteLog(LogLevel.Error, t, "RandomCode Invalid");

                rsp.Result = CommandUtil.RETURN.ERROR_RANDOMCODE_INVALID;
                return rsp;
            }

            try
            {
                bool ret = repository.ResetPassword(item.Mobile, item.Password);

                if (ret)
                {
                    rsp.Result = CommandUtil.RETURN.SUCCESS;
                }
                else
                {
                    rsp.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                }
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                rsp.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                return rsp;
            }

            return rsp;
        }

        // 获取短信验证码
        // POST api/user/fetchrandomcode
        public ReturnResult fetchRandomCode([FromBody] GetRandomCodeReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            ReturnResult ret = new ReturnResult();

            bool checkToken = ServiceToken.Intance().isTokenValid(item.Mobile, item.Token);
            if (checkToken == false)
            {
                LogHelper.WriteLog(LogLevel.Error, t, "Token Invalid");

                ret.Result = CommandUtil.RETURN.ERROR_TOKEN_INVALID;
                return ret;
            }

            try
            {
                Service_SMS _smsService = Service_SMS.Instance();
                _smsService.SendRandomCode(item.Mobile);

                ret.Result = CommandUtil.RETURN.SUCCESS;
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_UNKNOW;
                return ret;
            }

            return ret;
        }
    }
}
