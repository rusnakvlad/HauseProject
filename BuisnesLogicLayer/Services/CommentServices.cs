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
        /*--------------------Common Methods from Generic repository--------------------*/
        public IEnumerable<CommentCreateDTO> GetAllComments()
        {
            var comments = Database.CommentRepository.GetAll();
            foreach (var comment in comments)
            {
                yield return new CommentCreateDTO()
                {
                    AdId = comment.AdId,
                    UserID = comment.UserID,
                    DateOfComment = comment.DateOfComment,
                    Text = comment.Text
                };
            }
        }

        public CommentCreateDTO GetCommentById(int id)
        {
            var comment = Database.CommentRepository.GetById(id);
            return new CommentCreateDTO
            {
                AdId = comment.AdId,
                UserID = comment.UserID,
                DateOfComment = comment.DateOfComment,
                Text = comment.Text
            };
        }

        public void AddNewComment(CommentCreateDTO commentDTO)
        {
            Database.CommentRepository.Add(ConvertToComment.FromCommentDTO(commentDTO));
        }

        public void DeleteCommentById(int id)
        {
            Database.CommentRepository.DeleteById(id);
        }

        public void UpdateComment(CommentInfoAndEditIDTO commentEditDTO)
        {
            Database.CommentRepository.Update(ConvertToComment.FromCommentEditDTO(commentEditDTO));
        }

        /*------------------------------Individual methods------------------------------*/
        public IEnumerable<CommentCreateDTO> GetCommentsByAdId(int adId)
        {
            var comments = Database.CommentRepository.GetCommentsByAdId(adId);
            foreach (var comment in comments)
            {
                yield return new CommentCreateDTO()
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
