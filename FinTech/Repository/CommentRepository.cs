using FinTech.Data;
using FinTech.Dtos.Comment;
using FinTech.Interfaces;
using FinTech.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FinTech.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> DeleteComment(int id)
        {
            var comment = _context.Comments.Find(id);
            if (comment == null)
            {
                return null;
            }
             _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return comment;

        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);

        }

        public async Task<Comment?> UpdateComment(int id, UpdateCommentDto updateCommentDto)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return null;
            }
            comment.Title = updateCommentDto.Title;
            comment.Content = updateCommentDto.Content;
            await _context.SaveChangesAsync();
            return comment;
        }
    }

}