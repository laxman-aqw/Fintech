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
        private readonly IStockRepository _stockRepo;
        private readonly ICommentRepository _commentRepo;
        public CommentController(ICommentRepository commentRepo, IStockRepository stockRepo)
        {
            _stockRepo = stockRepo;
            _commentRepo = commentRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comment>>> GetComments() {

           
            var comments = (await _commentRepo.GetAllAsync()).Select(s => s.ToCommentDto()).ToList();
            if (comments.Count == 0)
            {
                return NotFound(new { message = "No comments found.", success = false });
            }
            return Ok(comments);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CommentDto>> GetCommentById(int id)
        {
          
            var comment = await _commentRepo.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound(new { message = "Comment not found.", success = false });
            }
            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{stockId:int}")]
        public async Task<ActionResult> CreateComment(int stockId, CreateCommentDto commentDto) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _stockRepo.StockExist(stockId))
            {
                return BadRequest("Stock doest not exist");
            }
            var comment = commentDto.ToCommentFromCreate(stockId);
            await _commentRepo.CreateAsync(comment);
            return CreatedAtAction(nameof(GetCommentById), new { id = comment.Id }, comment.ToCommentDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteComment(int id) {
            
            var comment = await _commentRepo.DeleteComment(id);
            if (comment == null)
            {
                return NotFound(new { message = "Comment not found.", success = false });
            }
            return NoContent();

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateComment(int id, UpdateCommentDto updateCommentDto) {
            var comment = await _commentRepo.UpdateComment(id, updateCommentDto);
            if (comment == null)
            {
                return NotFound(new { message = "Comment not found.", success = false });
            }
            return Ok(comment.ToCommentDto());
        }

    }
}
