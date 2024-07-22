using PostCentral.Models;

namespace PostCentral.Services.Interfaces;

public interface ICommentService
{
    Task<List<Comment>> GetAllCommentsAsync();

    Task<List<Comment>> GetByPostIdAsync(Guid postId);

    Task<List<Comment>> GetByUserIdAsync(Guid userId);

    Task<Comment?> GetByIdAsync(Guid commentId);

    Task<Comment?> CreateCommentAsync(Comment comment);

    Task<Comment?> UpdateCommentAsync(Comment comment);

    Task<Comment?> DeleteCommentAsync(Guid commentId);
}