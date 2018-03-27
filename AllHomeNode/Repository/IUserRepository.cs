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
        IEnumerable<User> GetAll();
        User Get(string mobile);
        User Add(User item);
        void Remove(string mobile);
        bool Update(User item)
    }
}
