using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using DataAccesLayer.EF;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(IAdRepository adRepository, ICommentRepository commentRepository,
           /* IFavoriteRepository favoriteRepository, IForCompareRepository forCompareRepository,
            IImageRepository imageRepository, ITagRepository tagRepository,*/ IUserRepository userRepository)
        {
            UserRepository = userRepository;
            AdRepository = adRepository;
            CommentRepository = commentRepository;
           /* FavoriteRepository = favoriteRepository;
            ForCompareRepository = forCompareRepository;
            ImageRepository = imageRepository;
            TagRepository = tagRepository;
            UserRepository = userRepository;*/
        }
        public IAdRepository AdRepository { get; set; }

        public ICommentRepository CommentRepository { get; set; }

       /* public IFavoriteRepository FavoriteRepository { get; set; }

        public IForCompareRepository ForCompareRepository { get; set; }

        public IImageRepository ImageRepository { get; set; }

        public ITagRepository TagRepository { get; set; }*/

        public IUserRepository UserRepository { get; set; }
        
    }
}
