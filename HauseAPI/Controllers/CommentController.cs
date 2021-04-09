using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnesLogicLayer.Interfaces;
using BuisnesLogicLayer.Services;
using BuisnesLogicLayer.DTO;

namespace HauseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : Controller
    {
        private readonly ICommentServices commentServices = new CommentServices();

        [HttpGet("/comment/{adId}")]
        public IEnumerable<CommentDTO> GetCommentsByAdId(int adId)
        {
           return commentServices.GetCommentsByAdId(adId);
        }

        [HttpGet]
        public IEnumerable<CommentDTO> GetAllComments()
        {
            return commentServices.GetAllComments();
        }

        [HttpPost]
        public void AddNewComment([FromBody] CommentDTO commentDTO)
        {
            commentServices.AddNewComment(commentDTO);
        }

        [HttpDelete("/comment/{userId}/{adId}")]
        public void RemoveCommentByUserIdAndAdId(int userId, int adId)
        {
            commentServices.RemoveCommentByUserIdAndAdId(userId, adId);
        }
    }
}
