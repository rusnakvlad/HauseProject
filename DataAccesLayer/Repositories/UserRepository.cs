using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using DataAccesLayer.EF;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DataAccesLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDBContext context;

        public UserManager<User> UserManager { get; set; }
        public RoleManager<IdentityRole> RoleManager { get; set; }
        public SignInManager<User> SignInManager { get; set; }

        public UserRepository(AppDBContext context, UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            this.context = context;
            UserManager = userManager;
            RoleManager = roleManager;
            SignInManager = signInManager;

        }

        public async Task<bool> Add(User entity)
        {
            if(context.Users.Any(user => user.Email == entity.Email))
            {
                throw new Exception("There is already an user with such email");
            }
            var result = await UserManager.CreateAsync(entity);
            await context.SaveChangesAsync();
            await UserManager.AddToRoleAsync(entity,"User");          
            return result.Succeeded;
        }

        public async Task<bool> Delete(User entity)
        {
            if (context.Users.All(user => user != entity))
            {
                throw new Exception("Thre is not such a user to delete");
            }
            var result = await UserManager.DeleteAsync(entity);
            await context.SaveChangesAsync();
            return result.Succeeded;
        }

        public async Task<bool> DeleteById(string id)
        {
            var user = await context.Users.FindAsync(id);
            return await this.Delete(user);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            if (!context.Users.Any())
            {
                throw new Exception("Thre are not users in database");
            }
            return await Task.Run(() => UserManager.Users);
        }

        public async Task<User> GetById(string id)
        {
            if(context.Users.All(user => user.Id != id))
            {
                throw new Exception($"There is not a user with id: {id}");
            }
            return await UserManager.FindByIdAsync(id);
        }

        public async Task<bool> Update(User entity)
        {
            if(context.Users.All(user => user.Id != entity.Id))
            {
                throw new Exception("Thtere is not such a user to edit");
            }
            var result = await UserManager.UpdateAsync(entity);
            return result.Succeeded;
        }

        public async Task<User> GetByEmail(string email)
        {
            if(context.Users.All(user => user.Email != email))
            {
                throw new Exception("There is not a user with such an email");
            }
            return await UserManager.FindByEmailAsync(email);
        }
    }
}
