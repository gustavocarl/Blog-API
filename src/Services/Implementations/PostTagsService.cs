using PostCentral.Models;
using PostCentral.Repositories.Interfaces;
using PostCentral.Services.Interfaces;

namespace PostCentral.Services.Implementations;

public class PostTagsService(IPostTagsRepository postTagsRepository) : IPostTagsService
{
    private readonly IPostTagsRepository _postTagsRepository = postTagsRepository;

    public async Task CreatePostTagsAsync(PostTags postTags)
    {
        await _postTagsRepository.AddPostTagsAsync(postTags);
    }
}