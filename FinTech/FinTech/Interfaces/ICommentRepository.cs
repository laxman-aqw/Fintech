using FinTech.Dtos.Comment;
using FinTech.Models;
using System.Net;

namespace FinTech.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment> CreateAsync(Comment comment);

        Task<Comment?> DeleteComment(int id);
        Task<Comment?> UpdateComment(int id, UpdateCommentDto updateCommentDto);
    }
}
