using PostCentral.Models;

namespace PostCentral.Services.Interfaces;

public interface IPostService
{
    Task<List<Post>?> GetAllPostsAsync();

    Task<Post?> GetPostByIdAsync(Guid id);

    Task<Post?> GetPostByTitleAsync(string title);

    Task<List<Post>?> GetPostByAuthorAsync(Guid id);

    Task<Post?> CreatePostAsync(Post post);

    Task<Post?> UpdatePostAsync(Post post);

    Task<Post?> DeletePostAsync(Guid id);
}