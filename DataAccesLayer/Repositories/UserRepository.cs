using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using DataAccesLayer.EF;
using System.Linq;

namespace DataAccesLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDBContext context;
        public UserRepository(AppDBContext context) => this.context = context;

        public void AddNewUser(User user)
        {
            context.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            context.Users.Remove(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return context.Users.ToList().Where(u => u.ID == id).FirstOrDefault();
        }

        public void UpdateUser(User user)
        {
            context.Users.Update(user);
        }
    }
}
