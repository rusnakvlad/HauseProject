using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnesLogicLayer.DTO;
using BuisnesLogicLayer.Interfaces;
using DataAccesLayer;
using DataAccesLayer.Repositories;
using DataAccesLayer.EF;
using DataAccesLayer.Interfaces;
using BuisnesLogicLayer.Converters;

namespace BuisnesLogicLayer.Services
{
    public class CommentServices : ICommentServices
    {
        private IUnitOfWork Database = new UnitOfWork(
               new AdRepository(new AppDBContext()),
               new CommentRepository(new AppDBContext()),
               new FavoriteRepository(new AppDBContext()),
               new ForCompareRepository(new AppDBContext()),
               new ImageRepository(new AppDBContext()),
               new TagRepository(new AppDBContext()),
               new UserRepository(new AppDBContext())
               );
        public void AddNewComment(CommentDTO commentDTO)
        {
            Database.CommentRepository.AddNewComment(ConvertToComment.FromCommentDTO(commentDTO));
        }

        public IEnumerable<CommentDTO> GetAllComments()
        {
            var comments = Database.CommentRepository.GetComments();
            foreach (var comment in comments)
            {
                yield return new CommentDTO()
                {
                    AdId = comment.AdId,
                    UserID = comment.UserID,
                    DateOfComment = comment.DateOfComment,
                    Text = comment.Text
                };
            }
        }

        public IEnumerable<CommentDTO> GetCommentsByAdId(int adId)
        {
            var comments = Database.CommentRepository.GetCommentsByAdId(adId);
            foreach (var comment in comments)
            {
                yield return new CommentDTO()
                {
                    AdId = comment.AdId,
                    UserID = comment.UserID,
                    DateOfComment = comment.DateOfComment,
                    Text = comment.Text
                };
            }
        }

        public void RemoveCommentByUserIdAndAdId(int userId, int adId)
        {
            Database.CommentRepository.RemoveCommentByUserIdAndAdId(userId, adId);
        }
    }
}
