using System.Collections.Generic;
using UserList.Models;

namespace UserList.Services
{
    public interface IUserServices
    {
         bool AddUsers(UserLIstModel userLIstModel);
        List<UserLIstModel> GetUser(UserLIstModel UserLIstModel);
         UserLIstModel Edit(int id);
        bool Edit(UserLIstModel userLIstModel);
        bool Delete(int id);
    }
}