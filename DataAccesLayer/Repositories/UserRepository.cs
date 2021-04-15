using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using DataAccesLayer.EF;
using System.Linq;

namespace DataAccesLayer.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private AppDBContext context;
        public UserRepository(AppDBContext context) : base(context) => this.context = context;
    }
}
