using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectASP.NET.Models;

namespace ProjectASP.NET
{
    public interface ICRUDUserRepository
    {
        UserModel FindUser(int id);
        UserModel AddUser(UserModel user);

        UserModel DeleteUser(int id);

        UserModel UpdateUser(UserModel user);

        List<UserModel> FindAllUsers();

    }
}
