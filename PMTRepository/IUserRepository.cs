using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMTRepository
{
    interface IUserRepository
    {
        User_Info login(string username, string password);
        List<User_Info> all_user();
        User_Info user (int id);
        int Insert(User_Info user);
        int Delete(int id);
        int Update(User_Info user);
    }
}
