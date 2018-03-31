using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

using AllHomeNode.model;
using AllHomeNode.Repository;
using AllHomeNode.Auth;

namespace AllHomeNode.controller
{
    public class UserController : ApiController
    {
        private UserRepository repository = new UserRepository();

        // GET /api/user
        public IEnumerable<UserData> GetAllUsers()
        {
            return repository.GetAll();
        }

        // GET /api/user/?mobile=mobile
        public IEnumerable<UserData> GetUsersByMobile(string mobile)
        {
            List<UserData> datas = repository
                .GetAll()
                .Where(r => string.Equals(r.Mobile, mobile))
                .Select(r => r).ToList();
            return datas;
        }

        // 注册用户
        // POST api/user/register
        public ReturnResult Register([FromBody]UserData item)
        {
            repository.Add(item);
            ReturnResult ret = new ReturnResult();
            ret.Result = CommandUtil.RETURN.SUCCESS;
            return ret;
        }

        // 修改用户信息
        // POST api/user/update
        public ReturnResult Update([FromBody]UserData item)
        {
            repository.Update(item);
            ReturnResult ret = new ReturnResult();
            ret.Result = CommandUtil.RETURN.SUCCESS;
            return ret;
        }

        // 用户登陆
        // POST api/user/login
        public ReturnResult Login([FromBody]LoginReqData item)
        {
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
        // POST api/user/getrandomcode
        public ReturnResult GetRandomCode([FromBody] GetRandomCodeReqData item)
        {
            ReturnResult ret = new ReturnResult();
            ret.Result = CommandUtil.RETURN.SUCCESS;

            return ret;
        }


    }
}
