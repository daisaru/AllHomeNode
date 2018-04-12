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
            return repository.GetAll();
        }

        // 获取用户信息
        // POST /api/user/fetchuserinfo
        public GetUserInfoRspData FetchUserInfo([FromBody]GetUserInfoReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            UserData data = repository
                .GetAll()
                .Where(r => string.Equals(r.Mobile, item.Mobile))
                .Select(r => r).ToList()[0];
            data.Password = "";
            data.RandomCode = "";
            GetUserInfoRspData ret = new GetUserInfoRspData();
            ret.Result = CommandUtil.RETURN.SUCCESS;
            ret.User = data;
            return ret;
        }

        // 注册用户
        // POST api/user/register
        public ReturnResult Register([FromBody]UserData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            repository.Add(item);
            ReturnResult ret = new ReturnResult();
            ret.Result = CommandUtil.RETURN.SUCCESS;
            return ret;
        }

        // 修改用户信息
        // POST api/user/update
        public ReturnResult Update([FromBody]UserData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            repository.Update(item);
            ReturnResult ret = new ReturnResult();
            ret.Result = CommandUtil.RETURN.SUCCESS;
            return ret;
        }

        // 用户登陆
        // POST api/user/login
        public ReturnResult Login([FromBody]LoginReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            bool ret = repository.Login(item.Mobile, item.Password);

            LoginRspData rsp = new LoginRspData();
            if (ret)
            {
                rsp.Result = CommandUtil.RETURN.SUCCESS;
                Token token = ServiceToken.Intance().GetandRefreshToken(item.Mobile);
                rsp.Token = token.TokenString;
                rsp.TimeStamp = token.StartTime.ToString();
                rsp.TokenLife = token.TokenLife.ToString();
            }
            else
            {
                rsp.Result = CommandUtil.RETURN.ERROR_UNKNOW;
            }


            return rsp;
        }

        // 重置密码
        // POST api/user/resetpassword
        public ReturnResult ResetPassword([FromBody] ResetPasswordReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            bool ret = repository.ResetPassword(item.Mobile, item.Password);
            ReturnResult rsp = new ReturnResult();
            if(ret)
            {
                rsp.Result = CommandUtil.RETURN.SUCCESS;
            }
            else
            {
                rsp.Result = CommandUtil.RETURN.ERROR_UNKNOW;
            }

            return rsp;
        }

        // 获取短信验证码
        // POST api/user/fetchrandomcode
        public ReturnResult fetchRandomCode([FromBody] GetRandomCodeReqData item)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            LogHelper.WriteLog(LogLevel.Warn, t, item);

            Service_SMS _smsService = Service_SMS.Instance();
            _smsService.SendRandomCode(item.Mobile);

            ReturnResult ret = new ReturnResult();
            ret.Result = CommandUtil.RETURN.SUCCESS;

            return ret;
        }


    }
}
