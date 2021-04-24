using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorFront.ViewModels;

namespace BlazorFront.Services
{
    public interface IUserServices
    {
        public Task<UserViewModel> GetUserByEmail(string email);
    }
}
