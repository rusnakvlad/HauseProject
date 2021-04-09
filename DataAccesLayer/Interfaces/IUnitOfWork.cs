using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using System.Threading.Tasks;

namespace DataAccesLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IAdRepository AdRepository { get; }
        ICommentRepository CommentRepository { get; }
        IFavoriteRepository FavoriteRepository { get; }
        IForCompareRepository ForCompareRepository { get; }
        IImageRepository ImageRepository { get; }
        ITagRepository TagRepository { get; }
        IUserRepository UserRepository { get; }
    }
}
