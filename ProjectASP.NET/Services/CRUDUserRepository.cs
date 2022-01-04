using ProjectASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectASP.NET
{
    public class CRUDUserRepository : ICRUDUserRepository
    {
        private ApplicationDbContext _context;

        public CRUDUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public UserModel FindUser(int id)
        {
            return _context.Users.Find(id);
        }

        public UserModel AddUser(UserModel user)
        {
            var entity = _context.Users.Add(user).Entity;
            _context.SaveChanges();
            return entity;
        }

        public UserModel UpdateUser(UserModel user)
        {
            var entity = _context.Users.Update(user).Entity;
            _context.SaveChanges();
            return entity;
        }

        public UserModel DeleteUser(int id)
        {
            var entity = _context.Users.Remove(FindUser(id)).Entity;
            _context.SaveChanges();
            return entity;
        }

        public List<UserModel> FindAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}
