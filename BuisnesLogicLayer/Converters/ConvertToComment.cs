using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Enteties;
using BuisnesLogicLayer.DTO;

namespace BuisnesLogicLayer.Converters
{
    public static class ConvertToComment
    {
        public static Comment FromCommentDTO(CommentDTO commentDTO)
        {
            return new Comment()
            {
                AdId = commentDTO.AdId,
                UserID = commentDTO.UserID,
                DateOfComment = commentDTO.DateOfComment,
                Text = commentDTO.Text
            };
        }
    }
}
