using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public UserModel FindUserById(int id)
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
            UserModel original = _context.Users.Find(user.UserId);
            original.Name = user.Name;
            original.Surname = user.Surname;
            original.Email = user.Email;
            original.Phone = user.Phone;
            EntityEntry<UserModel> entityEntry = _context.Users.Update(original);
            _context.SaveChanges();
            return entityEntry.Entity;
        }

        public void DeleteUser(int id)
        {
            _context.Users.Remove(_context.Users.Find(id));
            _context.SaveChanges();
        }

        public List<UserModel> FindAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}
