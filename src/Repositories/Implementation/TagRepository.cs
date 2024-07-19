using Blog_API.Context;
using Blog_API.Models;
using Blog_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog_API.Repositories.Implementation;

public class TagRepository(BlogContext context) : ITagRepository
{
    private readonly BlogContext _context = context;

    public async Task<List<Tag>> GetAllTagsAsync()
    {
        return await _context.Tags
                             .ToListAsync();
    }

    public async Task<Tag?> GetByIdAsync(Guid tagId)
    {
        return await _context.Tags
                             .FindAsync(tagId);
    }

    public async Task<Tag?> GetByTagNameAsync(string tagName)
    {
        return await _context.Tags
                             .FirstOrDefaultAsync(t => t.TagName == tagName);
    }

    public async Task<Tag?> AddTagAsync(Tag tag)
    {
        _context.Add(tag);

        await _context.SaveChangesAsync();

        return tag;
    }

    public async Task<Tag?> UpdateTagAsync(Tag tag)
    {
        var updateTag = await _context.Tags.FindAsync(tag.Id);

        if (updateTag == null)
            return null;

        _context.Entry(updateTag).CurrentValues.SetValues(tag);

        await _context.SaveChangesAsync();

        return tag;
    }

    public async Task<Tag?> DeleteTagAsync(Guid tagId)
    {
        var tagToDelete = await _context.Tags.FindAsync(tagId);

        if (tagToDelete == null)
            return null;

        _context.Tags.Remove(tagToDelete);

        await _context.SaveChangesAsync();

        return tagToDelete;
    }
}