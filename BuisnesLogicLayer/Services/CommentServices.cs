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
        private IUnitOfWork Database;
        public CommentServices(IUnitOfWork unitOfWork) => Database = unitOfWork;
        /*--------------------Common Methods from Generic repository--------------------*/
        public async Task<IEnumerable<CommentCreateDTO>> GetAllComments()
        {
            var comments = await Database.CommentRepository.GetAll();
            List<CommentCreateDTO> commentCreateDTOs = new();
            foreach (var comment in comments)
            {
                commentCreateDTOs.Add(new CommentCreateDTO()
                {
                    AdId = comment.AdId,
                    UserID = comment.UserID,
                    DateOfComment = comment.DateOfComment,
                    Text = comment.Text
                });
            }
            return commentCreateDTOs;
        }

        public async Task<CommentCreateDTO> GetCommentById(int id)
        {
            var comment = await Database.CommentRepository.GetById(id);
            return new CommentCreateDTO
            {
                AdId = comment.AdId,
                UserID = comment.UserID,
                DateOfComment = comment.DateOfComment,
                Text = comment.Text
            };
        }

        public async Task AddNewComment(CommentCreateDTO commentDTO)
        {
            await Database.CommentRepository.Add(ConvertToComment.FromCommentDTO(commentDTO));
        }

        public async Task DeleteCommentById(int id)
        {
            await Database.CommentRepository.DeleteById(id);
        }

        public async Task UpdateComment(CommentInfoAndEditIDTO commentEditDTO)
        {
            await Database.CommentRepository.Update(ConvertToComment.FromCommentEditDTO(commentEditDTO));
        }

        /*------------------------------Individual methods------------------------------*/
        public async Task<IEnumerable<CommentCreateDTO>> GetCommentsByAdId(int adId)
        {
            var comments = await Database.CommentRepository.GetCommentsByAdId(adId);
            List<CommentCreateDTO> commentCreateDTOs = new();
            foreach (var comment in comments)
            {
                commentCreateDTOs.Add(new CommentCreateDTO()
                {
                    AdId = comment.AdId,
                    UserID = comment.UserID,
                    DateOfComment = comment.DateOfComment,
                    Text = comment.Text
                });
            }
            return commentCreateDTOs;
        }

        public async Task RemoveCommentByUserIdAndAdId(string userId, int adId)
        {
            await Database.CommentRepository.RemoveCommentByUserIdAndAdId(userId, adId);
        }
    }
}
