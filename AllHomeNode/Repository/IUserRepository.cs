using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AllHomeNode.model;

namespace AllHomeNode.Repository
{
    public interface IUserRepository
    {
        IEnumerable<UserData> GetAll();
        UserData Get(string mobile);
        UserData Add(UserData item);
        void Remove(string mobile);
        bool Update(UserData item);
    }
}
