using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AllHomeNode.model;

namespace AllHomeNode.Repository
{
    public class UserRepository : IUserRepository
    {
        private List<UserData> users = new List<UserData>();

        public UserRepository()
        {
            Address address = new Address() {Number="40-401", Street="Xuanzhong RD", City="SH", Province="SH", Country="CN", Zipcode="201314"};

            users.Add(new UserData {NickName="daisaru", RealName="张三",Mobile="13601622425",Email="18371320@qq.com",Password="123456",RandomCode="2222", Address=address});
            users.Add(new UserData { NickName = "doggy", RealName = "里斯", Mobile = "18017052425", Email = "27268026@qq.com", Password = "123456", RandomCode = "1111", Address = address });
        }

        public IEnumerable<UserData> GetAll()
        {
            return users;
        }

        public UserData Get(string mobile)
        {
            return users.Find(p => p.Mobile == mobile);
        }

        public UserData Add(UserData item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("user item");
            }
            users.Add(item);
            return item;
        }

        public bool Update(UserData item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("user item");
            }
            int index = users.FindIndex(p => p.Mobile == item.Mobile);
            if(index == -1)
            {
                return false;
            }
            users.RemoveAt(index);
            users.Add(item);
            return true;
        }

        public void Remove(string mobile)
        {
            users.RemoveAll(p => p.Mobile == mobile);
        }

    }
}
