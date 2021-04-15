using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using DataAccesLayer.EF;
using System.Linq;

namespace DataAccesLayer.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private AppDBContext context;
        public CommentRepository(AppDBContext context) : base(context)=> this.context = context;

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
