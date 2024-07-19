using Blog_API.Models;

namespace Blog_API.Services.Interfaces;

public interface IPostTagsService
{
    Task CreatePostTagsAsync(PostTags postTags);
}