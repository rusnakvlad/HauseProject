using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Enteties;

namespace DataAccesLayer.Interfaces
{
    public interface IUserRefreshTokenRepository : IGenericRepository<UsersRefreshToken>
    {
        public Task UpdateToken(UsersRefreshToken usersRefreshToken);
        public Task<UsersRefreshToken> GetTokenByUserId(string userId);
    }
}
