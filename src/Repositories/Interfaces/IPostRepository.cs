using Blog_API.Models;

namespace Blog_API.Repositories.Interfaces;

public interface IPostRepository
{
    Task<List<Post>> GetAllAsync();

    Task<Post?> GetByIdAsync(Guid id);

    Task<Post?> GetByTitleAsync(string title);

    Task<List<Post>> GetByAuthorAsync(Guid authorId);

    Task<Post?> AddPostAsync(Post post);

    Task<Post?> UpdatePostAsync(Post post);

    Task<Post?> DeletePostAsync(Guid id);
}