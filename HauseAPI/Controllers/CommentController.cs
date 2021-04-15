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
        // Get all comments
        [HttpGet]
        public IEnumerable<CommentCreateDTO> GetAllComments() => commentServices.GetAllComments();
        

        [HttpGet("/Comment/{id}")]
        public CommentCreateDTO GetCommentById(int id) => commentServices.GetCommentById(id);
        

        // Get comments by adId
        [HttpGet("/Comment/ad/{adId}")]
        public IEnumerable<CommentCreateDTO> GetCommentsByAdId(int adId) => commentServices.GetCommentsByAdId(adId);
        

        // Add new comment
        [HttpPost]
        public void AddNewComment([FromBody] CommentCreateDTO commentDTO) => commentServices.AddNewComment(commentDTO);
        

        // Delete comment by ID
        [HttpDelete("/Comment/{id}")]
        public void RemoveCommentById(int id) => commentServices.DeleteCommentById(id);
        

        // Delete comment by userId and adId
        [HttpDelete("/Comment/{userId}/{adId}")]
        public void RemoveCommentByUserIdAndAdId(int userId, int adId) => commentServices.RemoveCommentByUserIdAndAdId(userId, adId);
        

        // Edit comment
        [HttpPut]
        public void UpdateComment([FromBody] CommentInfoAndEditIDTO commentEditDTO) => commentServices.UpdateComment(commentEditDTO);
        
    }
}
