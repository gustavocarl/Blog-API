using Blog_API.Models;

namespace Blog_API.Repositories.Interfaces;

public interface IPostTagsRepository
{
    Task AddPostTagsAsync(PostTags postTags);
}