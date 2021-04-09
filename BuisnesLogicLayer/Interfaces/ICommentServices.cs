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
        public IEnumerable<CommentDTO> GetCommentsByAdId(int adId);
        public void AddNewComment(CommentDTO commentDTO);
        public void RemoveCommentByUserIdAndAdId(int userId, int adId);
        public IEnumerable<CommentDTO> GetAllComments();
    }
}
