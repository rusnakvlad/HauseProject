using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using System.Threading.Tasks;

namespace DataAccesLayer.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        IAdRepository AdRepository { get; }
        ICommentRepository CommentRepository { get; }
        IFavoriteRepository FavoriteRepository { get; }
        IForCompareRepository ForCompareRepository { get; }
        IImageRepository ImageRepository { get; }
        ITagRepository TagRepository { get; }
        IUserRepository UserRepository { get; }

        //public UserManager<User> UserManager { get; set; }
        //public RoleManager<IdentityRole> RoleManager { get; set; }
        //public SignInManager<User> SignInManager { get; set; }

        Task SaveAsync();
    }
}
