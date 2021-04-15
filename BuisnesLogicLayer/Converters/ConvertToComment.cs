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
        public static Comment FromCommentDTO(CommentCreateDTO DTO)
        {
            return new Comment()
            {
                AdId = DTO.AdId,
                UserID = DTO.UserID,
                DateOfComment = DTO.DateOfComment,
                Text = DTO.Text
            };
        }

        public static Comment FromCommentEditDTO(CommentInfoAndEditIDTO DTO)
        {
            return new Comment()
            {
                ID = DTO.Id,
                AdId = DTO.AdId,
                UserID = DTO.UserID,
                DateOfComment = DTO.DateOfComment,
                Text = DTO.Text
            };
        }
    }
}
