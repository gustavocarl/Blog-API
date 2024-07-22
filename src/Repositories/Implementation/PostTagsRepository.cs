using PostCentral.Context;
using PostCentral.Models;
using PostCentral.Repositories.Interfaces;

namespace PostCentral.Repositories.Implementation;

public class PostTagsRepository(BlogContext context) : IPostTagsRepository
{
    private readonly BlogContext _context = context;

    public async Task AddPostTagsAsync(PostTags postTags)
    {
        _context.PostTags.Add(postTags);

        await _context.SaveChangesAsync();
    }
}