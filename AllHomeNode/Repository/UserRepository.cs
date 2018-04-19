using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AllHomeNode.Front;
using AllHomeNode.Database.Model;
using AllHomeNode.Database.Manager;

namespace AllHomeNode.Repository
{
    public class UserRepository
    {
        //private List<UserData> users = new List<UserData>();

        public UserRepository()
        {
            //Address address = new Address() {Number="40-401", Street="Xuanzhong RD", City="SH", Province="SH", Country="CN", Zipcode="201314"};
            //users.Add(new UserData {NickName="daisaru", RealName="张三",Mobile="13601622425",Email="18371320@qq.com",Password="123456",RandomCode="2222", Address=address});
            //users.Add(new UserData { NickName = "doggy", RealName = "里斯", Mobile = "18017052425", Email = "27268026@qq.com", Password = "123456", RandomCode = "1111", Address = address });
        }

        private User FillUserObject(UserData data)
        {
            User user = new User();
            user.NickName = data.NickName;
            user.RealName = data.RealName;
            user.Mobile = data.Mobile;
            user.Email = data.Email;
            user.Password = data.Password;
            user.Address_Number = data.Address.Number;
            user.Address_Street = data.Address.Street;
            user.Address_City = data.Address.City;
            user.Address_Province = data.Address.Province;
            user.Address_Country = data.Address.Country;
            user.Address_ZipCode = data.Address.ZipCode;
            return user;
        }

        private UserData FillUserDataObject(User user)
        {
            UserData data = new UserData();
            data.NickName = user.NickName;
            data.RealName = user.RealName;
            data.Mobile = user.Mobile;
            data.Email = user.Email;
            data.Password = user.Password;
            data.Address.Number = user.Address_Number;
            data.Address.Street = user.Address_Street;
            data.Address.City = user.Address_City;
            data.Address.Province = user.Address_Province;
            data.Address.Country = user.Address_Country;
            data.Address.ZipCode = user.Address_ZipCode;
            return data;
        }

        public IEnumerable<UserData> GetAll()
        {
            List<UserData> userdata = new List<UserData>();
            UserManager userMgr = new UserManager();
            List<User> users = userMgr.GetUserList().ToList();
            foreach(User user in users)
            {
                UserData data = FillUserDataObject(user);
                userdata.Add(data);
            }
            return userdata;
        }

        public UserData Get(string mobile)
        {
            UserManager userMgr = new UserManager();
            List<User> users = userMgr.GetUserByMobile(mobile).ToList();
            if(users == null || users.Count == 0)
            {
                return null;
            }
            UserData data = FillUserDataObject(users[0]);
            return data;
        }

        public UserData Add(UserData item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("user item");
            }

            UserData tmp = Get(item.Mobile);
            if(tmp != null)
            {
                return null;
            }

            User user = FillUserObject(item);
            user.Id = Guid.NewGuid().ToString("N");
            user.TimeStamp = DateTime.Now;
            UserManager userMgr = new UserManager();
            userMgr.Add(user);
            return item;
        }

        public bool Update(UserData item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("user item");
            }

            UserData tmp = Get(item.Mobile);
            if (tmp == null)
            {
                return false;
            }

            User user = FillUserObject(item);
            UserManager userMgr = new UserManager();
            User olduser = userMgr.GetUserByMobile(user.Mobile).ToList()[0];
            user.Id = olduser.Id;
            user.TimeStamp = DateTime.Now;
            userMgr.Update(user);
            return true;
        }

        public void Remove(string mobile)
        {
            UserManager userMgr = new UserManager();
            userMgr.Delete(mobile);
        }

        public bool Login(string mobile, string password)
        {
            UserManager userMgr = new UserManager();
            User user = userMgr.GetUserByMobile(mobile).ToList()[0];
            if(user.Password.Equals(password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ResetPassword(string mobile, string password)
        {
            UserManager userMgr = new UserManager();
            User user = userMgr.GetUserByMobile(mobile).ToList()[0];
            user.Password = password;
            bool ret = userMgr.Update(user);
            return ret;
        }

    }
}
