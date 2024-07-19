using Blog_API.Context;
using Blog_API.Models;
using Blog_API.Repositories.Interfaces;

namespace Blog_API.Repositories.Implementation;

public class PostTagsRepository(BlogContext context) : IPostTagsRepository
{
    private readonly BlogContext _context = context;

    public async Task AddPostTagsAsync(PostTags postTags)
    {
        _context.PostTags.Add(postTags);

        await _context.SaveChangesAsync();
    }
}