using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Enteties;
using BuisnesLogicLayer.DTO;
namespace BuisnesLogicLayer.Interfaces
{
    public interface ICommentServices
    {
        /*--------------------Common Methods from Generic repository--------------------*/
        public IEnumerable<CommentCreateDTO> GetAllComments();

        public CommentCreateDTO GetCommentById(int id);

        public void AddNewComment(CommentCreateDTO commentDTO);

        public void UpdateComment(CommentInfoAndEditIDTO commentEditDTO);

        public void DeleteCommentById(int id);

        /*------------------------------Individual methods------------------------------*/
        public IEnumerable<CommentCreateDTO> GetCommentsByAdId(int adId);

        public void RemoveCommentByUserIdAndAdId(int userId, int adId);
        
        
    }
}
