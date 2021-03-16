using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccesLayer.Enteties
{
    public class Comment
    {
        ////////////////////////////////////////////////
        public Ad ad { get; set; }
        public User user { get; set; }
        ////////////////////////////////////////////////

        public int ID { get; set; }
        public int UserID { get; set; }
        public int AdId { get; set; }
        public DateTime DateOfComment { get; set; }
        public string Text { get; set; }

        public Comment(int UserId, int AdId, DateTime DateOfComment, string Text)
        {
            this.UserId = UserId;
            this.AdId = AdId;
            this.DateOfComment = DateOfComment;
            this.Text = Text;
        }

        public Comment() { }
    }
}
