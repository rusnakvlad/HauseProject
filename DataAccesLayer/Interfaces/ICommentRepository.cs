using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccesLayer.Enteties;

namespace DataAccesLayer.Interfaces
{
    public interface ICommentRepository
    {
        public IEnumerable<Comment> GetCommentsByAdId(int adId);
        public void AddNewComment(Comment comment);
        public void RemoveCommentByUserIdAndAdId(int userId,int adId);

        public IEnumerable<Comment> GetComments();
    }
}
