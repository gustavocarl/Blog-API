using Blog_API.Models;
using Blog_API.Repositories.Interfaces;
using Blog_API.Services.Interfaces;

namespace Blog_API.Services.Implementations;

public class PostTagsService(IPostTagsRepository postTagsRepository) : IPostTagsService
{
    private readonly IPostTagsRepository _postTagsRepository = postTagsRepository;

    public async Task CreatePostTagsAsync(PostTags postTags)
    {
        await _postTagsRepository.AddPostTagsAsync(postTags);
    }
}