using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using DataAccesLayer.EF;

namespace DataAccesLayer.Repositories
{
    public class UserRefreshTokenRepository : GenericRepository<UsersRefreshToken>, IUserRefreshTokenRepository
    {
        public AppDBContext context;
        public UserRefreshTokenRepository(AppDBContext context) : base(context) => this.context = context;

        public async Task<UsersRefreshToken> GetTokenByUserId(string userId)
        {
            return await context.UsersRefreshTokens.FindAsync(userId);
        }

        public async Task UpdateToken(UsersRefreshToken usersRefreshToken)
        {
            var userToken = context.UsersRefreshTokens.ToList().Where(u => u.UserId == usersRefreshToken.UserId).FirstOrDefault();
            if(userToken != null)
            {
                userToken.Token = usersRefreshToken.Token;
            }
            else
            {
                context.UsersRefreshTokens.Add(usersRefreshToken);
            }
            await context.SaveChangesAsync();
        }
    }
}
