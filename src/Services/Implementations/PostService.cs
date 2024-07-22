using PostCentral.Models;
using PostCentral.Repositories.Interfaces;
using PostCentral.Services.Interfaces;

namespace PostCentral.Services.Implementations;

public class PostService(IPostRepository postRepository, IUserRepository userRepository) : IPostService
{
    private readonly IPostRepository _postRepository = postRepository;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<List<Post>?> GetAllPostsAsync()
    {
        return await _postRepository.GetAllAsync();
    }

    public async Task<Post?> GetPostByIdAsync(Guid id)
    {
        return await _postRepository.GetByIdAsync(id);
    }

    public async Task<Post?> GetPostByTitleAsync(string title)
    {
        return await _postRepository.GetByTitleAsync(title);
    }

    public async Task<List<Post>?> GetPostByAuthorAsync(Guid id)
    {
        return await _postRepository.GetByAuthorAsync(id);
    }

    public async Task<Post?> CreatePostAsync(Post post)
    {
        var user = await _userRepository.GetByIdAsync(post.UserId);

        if (user == null)
            return null;

        return await _postRepository.AddPostAsync(post);
    }

    public async Task<Post?> UpdatePostAsync(Post post)
    {
        return await _postRepository.UpdatePostAsync(post);
    }

    public async Task<Post?> DeletePostAsync(Guid id)
    {
        return await _postRepository.DeletePostAsync(id);
    }
}