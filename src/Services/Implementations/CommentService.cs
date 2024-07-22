using PostCentral.Models;
using PostCentral.Repositories.Interfaces;
using PostCentral.Services.Interfaces;

namespace PostCentral.Services.Implementations;

public class CommentService(ICommentRepository commentRepository, IPostRepository postRepository,
    IUserRepository userRepository) : ICommentService
{
    private readonly ICommentRepository _commentRepository = commentRepository;
    private readonly IPostRepository _postRepository = postRepository;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<List<Comment>> GetAllCommentsAsync()
    {
        return await _commentRepository.GetAllCommentsAsync();
    }

    public async Task<List<Comment>> GetByPostIdAsync(Guid postId)
    {
        var post = await _postRepository.GetByIdAsync(postId);

        if (post == null)
            return null!;

        return await _commentRepository.GetByPostIdAsync(postId);
    }

    public async Task<List<Comment>> GetByUserIdAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user == null)
            return null!;

        return await _commentRepository.GetByUserIdAsync(userId);
    }

    public async Task<Comment?> GetByIdAsync(Guid commentId)
    {
        return await _commentRepository.GetByIdAsync(commentId);
    }

    public async Task<Comment?> CreateCommentAsync(Comment comment)
    {
        var post = await _postRepository.GetByIdAsync(comment.PostId);

        var user = await _userRepository.GetByIdAsync(comment.UserId);

        if (post == null || user == null)
            return null;

        return await _commentRepository.AddCommentAsync(comment);
    }

    public async Task<Comment?> UpdateCommentAsync(Comment comment)
    {
        return await _commentRepository.UpdateCommentAsync(comment);
    }

    public async Task<Comment?> DeleteCommentAsync(Guid commentId)
    {
        return await _commentRepository.DeleteCommentAsync(commentId);
    }
}