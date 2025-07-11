using FinTech.Data;
using FinTech.Dtos.Comment;
using FinTech.Interfaces;
using FinTech.Mappers;
using FinTech.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        public CommentController(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comment>>> GetComments() {
            var comments = (await _commentRepo.GetAllAsync()).Select(s => s.ToCommentDto()).ToList();
            if(comments.Count == 0)
            {
                return NotFound(new { message = "No comments found.", success = false });
            }
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDto>> GetCommentById(int id)
        {
            var comment = await _commentRepo.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound(new { message = "Comment not found.", success = false });
            }
            return Ok(comment.ToCommentDto());
        }
    }
}
