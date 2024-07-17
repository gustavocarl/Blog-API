using Blog_API.Context;
using Blog_API.Models;
using Blog_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog_API.Repositories.Implementation;

public class CommentRepository(BlogContext context) : ICommentRepository
{
    private readonly BlogContext _context = context;

    public async Task<List<Comment>> GetAllCommentsAsync()
    {
        return await _context.Comments
                             .ToListAsync();
    }

    public async Task<List<Comment>> GetByPostIdAsync(Guid postId)
    {
        return await _context.Comments
                             .Where(c => c.PostId == postId)
                             .OrderByDescending(c => c.PublicationDate)
                             .ToListAsync();
    }

    public async Task<List<Comment>> GetByUserIdAsync(Guid userId)
    {
        return await _context.Comments
                             .Where(c => c.UserId == userId)
                             .OrderByDescending(c => c.PublicationDate)
                             .ToListAsync();
    }

    public async Task<Comment?> GetByIdAsync(Guid commentId)
    {
        return await _context.Comments
                             .FindAsync(commentId);
    }

    public async Task<Comment?> AddCommentAsync(Comment comment)
    {
        _context.Add(comment);

        await _context.SaveChangesAsync();

        return comment;
    }

    public async Task<Comment?> UpdateCommentAsync(Comment comment)
    {
        var commentToUpdate = await _context.Comments.FindAsync(comment.Id);

        if (commentToUpdate == null)
            return null;

        _context.Entry(commentToUpdate).CurrentValues.SetValues(comment);

        await _context.SaveChangesAsync();

        return comment;
    }

    public async Task<Comment?> DeleteCommentAsync(Guid commentId)
    {
        var commentToDelete = await _context.Comments.FindAsync(commentId);

        if (commentToDelete == null)
            return null;

        _context.Comments.Remove(commentToDelete);

        await _context.SaveChangesAsync();

        return commentToDelete;
    }
}