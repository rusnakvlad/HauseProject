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

        public IEnumerable<Comment> GetComments()
        {
            return context.Comments.ToList();
        }
    }
}
