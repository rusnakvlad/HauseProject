using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using DataAccesLayer.EF;
using System.Linq;

namespace DataAccesLayer.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDBContext context) : base(context) { }

        public IQueryable<User> GetAllUsers()
        {
            var users = context.Users.ToList();
            return (IQueryable<User>)users;
        }

        public User GetUserById(int id)
        {
            var user = context.Users.FirstOrDefault(user => user.ID == id);
            return user;
        }
    }
}
