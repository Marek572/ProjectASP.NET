using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectASP.NET.Models;

namespace ProjectASP.NET
{
    public interface ICRUDUserRepository
    {
        UserModel FindUserById(int id);

        UserModel AddUser(UserModel user);

        void DeleteUser(int id);

        UserModel UpdateUser(UserModel user);

        List<UserModel> FindAllUsers();

    }
}
