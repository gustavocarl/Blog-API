using PostCentral.Models;

namespace PostCentral.Repositories.Interfaces;

public interface IPostTagsRepository
{
    Task AddPostTagsAsync(PostTags postTags);
}