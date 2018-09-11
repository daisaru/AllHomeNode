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

                ret.Result = CommandUtil.RETURN.ERROR_USER_NOTFOUND;
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
                //先判断是否手机号已被注册
                UserData checkUser = repository.Get(item.Mobile);
                if (checkUser != null)
                {
                    ret.Result = CommandUtil.RETURN.ERROR_USER_MOBILEUSED;
                    return ret;
                }

                UserData user = repository.Add(item);

                if (user != null)
                {
                    ret.Result = CommandUtil.RETURN.SUCCESS;
                }
                else
                {
                    ret.Result = CommandUtil.RETURN.ERROR_DATABASE_ERROR;
                }
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_SERVICE_UNAVAILABLE;
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
            
            // 简单起见，不做随机码的验证。
            //bool checkRandomCode = Service_SMS.Instance().CheckRandomCode(item.Mobile, item.RandomCode);
            //if (checkRandomCode == false)
            //{
            //    LogHelper.WriteLog(LogLevel.Error, t, "RandomCode Invalid");

            //    ret.Result = CommandUtil.RETURN.ERROR_RANDOMCODE_INVALID;
            //    return ret;
            //}

            try
            {
                bool success = repository.Update(item);

                if (success)
                {
                    ret.Result = CommandUtil.RETURN.SUCCESS;
                }
                else
                {
                    ret.Result = CommandUtil.RETURN.ERROR_DATABASE_ERROR;
                }
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                ret.Result = CommandUtil.RETURN.ERROR_SERVICE_UNAVAILABLE;
                return ret;
            }

            return ret;
        }

        // 用户登陆
        // POST api/user/login
        public LoginRspData Login([FromBody]LoginReqData item)
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

                    UserData data = repository
                    .GetAll()
                    .Where(r => string.Equals(r.Mobile, item.Mobile))
                    .Select(r => r).ToList()[0];
                    data.Password = "";
                    data.RandomCode = "";

                    rsp.UserData = data;
                }
                else
                {
                    rsp.Result = CommandUtil.RETURN.ERROR_USER_LOGINFAILED;
                    rsp.UserData = null;
                    rsp.Token = "";
                    rsp.TimeStamp = "";
                    rsp.TokenLife = "";
                }
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                rsp.Result = CommandUtil.RETURN.ERROR_SERVICE_UNAVAILABLE;
                rsp.Token = "";
                rsp.TimeStamp = "";
                rsp.TokenLife = "";
                return rsp;
            }

            return rsp;
        }

        // 修改手机号
        // POST api/user/changemobile
        public ReturnResult ChangeMobile([FromBody] ChangeMobileReqData item)
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

            bool checkRandomCode = Service_SMS.Instance().CheckRandomCode(item.NewMobile, item.RandomCode);
            if (checkRandomCode == false)
            {
                LogHelper.WriteLog(LogLevel.Error, t, "RandomCode Invalid");

                rsp.Result = CommandUtil.RETURN.ERROR_RANDOMCODE_INVALID;
                return rsp;
            }

            try
            {
                //先判断是否手机号已被注册
                UserData checkuser = repository.Get(item.NewMobile);
                if (checkuser != null)
                {
                    rsp.Result = CommandUtil.RETURN.ERROR_USER_MOBILEUSED;
                    return rsp;
                }

                bool ret = repository.ChangeMobile(item.Mobile, item.NewMobile, item.Password);

                if (ret)
                {
                    rsp.Result = CommandUtil.RETURN.SUCCESS;
                }
                else
                {
                    rsp.Result = CommandUtil.RETURN.ERROR_DATABASE_ERROR;
                }
            }
            catch (Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                rsp.Result = CommandUtil.RETURN.ERROR_SERVICE_UNAVAILABLE;
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

            // Removed.
            // 忘记密码的时候。是没有获取token的 我现在token是登录以后才可以获得
            //bool checkToken = ServiceToken.Intance().isTokenValid(item.Mobile, item.Token);
            //if (checkToken == false)
            //{
            //    LogHelper.WriteLog(LogLevel.Error, t, "Token Invalid");

            //    rsp.Result = CommandUtil.RETURN.ERROR_TOKEN_INVALID;
            //    return rsp;
            //}

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
                    rsp.Result = CommandUtil.RETURN.ERROR_DATABASE_ERROR;
                }
            }
            catch(Exception exp)
            {
                LogHelper.WriteLog(LogLevel.Error, t, exp);

                rsp.Result = CommandUtil.RETURN.ERROR_SERVICE_UNAVAILABLE;
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
            checkToken = true; // 用户注册时需要获取短信码，不应该验证；
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

                ret.Result = CommandUtil.RETURN.ERROR_SERVICE_UNAVAILABLE;
                return ret;
            }

            return ret;
        }
    }
}
