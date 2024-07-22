using PostCentral.Models;

namespace PostCentral.Services.Interfaces;

public interface IPostTagsService
{
    Task CreatePostTagsAsync(PostTags postTags);
}