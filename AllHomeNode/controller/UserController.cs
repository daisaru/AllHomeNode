using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

using AllHomeNode.model;
using AllHomeNode.Repository;

namespace AllHomeNode.controller
{
    public class UserController : ApiController
    {
        private readonly IUserRepository repository = new UserRepository();

        // GET /api/user
        public IEnumerable<UserData> GetAllUsers()
        {
            return repository.GetAll();
        }

        // GET /api/user/?mobile=mobile
        public IEnumerable<UserData> GetUsersByMobile(string mobile)
        {
            return repository
                .GetAll()
                .Where(r => string.Equals(r.Mobile, mobile))
                .Select(r => r);
        }

        // 注册用户
        // POST api/user/register
        public ReturnResult Register([FromBody]UserData item)
        {
            ReturnResult ret = new ReturnResult();
            ret.Result = CommandUtil.RETURN.SUCCESS;
            return ret;
        }

        // 修改用户信息
        // POST api/user/update
        public ReturnResult Update([FromBody]UserData item)
        {
            ReturnResult ret = new ReturnResult();
            ret.Result = CommandUtil.RETURN.SUCCESS;
            return ret;
        }

        // 用户登陆
        // POST api/user/login
        public ReturnResult Login([FromBody]LoginReqData item)
        {
            LoginRspData ret = new LoginRspData();
            ret.Result = CommandUtil.RETURN.SUCCESS;
            ret.TimeStamp = "111";
            ret.Token = "sdfsdfsdf";
            ret.TokenLife = "100";

            return ret;
        }

        // 重置密码
        // POST api/user/resetpassword
        public ReturnResult ResetPassword([FromBody] ResetPasswordReqData item)
        {
            ReturnResult ret = new ReturnResult();
            ret.Result = CommandUtil.RETURN.SUCCESS;

            return ret;
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
