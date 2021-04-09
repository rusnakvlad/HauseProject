using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using DataAccesLayer.EF;
using System.Linq;

namespace DataAccesLayer.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private AppDBContext context;
        public CommentRepository(AppDBContext context) => this.context = context;

        public void AddNewComment(Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
        }

        public IEnumerable<Comment> GetComments()
        {
            return context.Comments.ToList();
        }

        public IEnumerable<Comment> GetCommentsByAdId(int adId)
        {
            return context.Comments.ToList().Where(coment => coment.AdId == adId);
        }

        public void RemoveCommentByUserIdAndAdId(int userId,int adId)
        {
            var commentToRemove = context.Comments.ToList().Where(coment => coment.UserID == userId && coment.AdId == adId).FirstOrDefault();
            context.Comments.Remove(commentToRemove);
            context.SaveChanges();
        }

        
    }
}
