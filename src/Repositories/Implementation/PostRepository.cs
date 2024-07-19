using Blog_API.Context;
using Blog_API.Models;
using Blog_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog_API.Repositories.Implementation;

public class PostRepository(BlogContext context) : IPostRepository
{
    private readonly BlogContext _context = context;

    public async Task<List<Post>> GetAllAsync()
    {
        return await _context.Posts
            .OrderByDescending(p => p.PublicationDate)
            .ToListAsync();
    }

    public async Task<Post?> GetByIdAsync(Guid id)
    {
        return await _context.Posts
            .FindAsync(id);
    }

    public async Task<Post?> GetByTitleAsync(string title)
    {
        return await _context.Posts
            .FirstOrDefaultAsync(p => p.Title == title);
    }

    public async Task<List<Post>> GetByAuthorAsync(Guid authorId)
    {
        return await _context.Posts
            .Include(p => p.User)
            .Where(p => p.UserId == authorId)
            .OrderByDescending(p => p.PublicationDate)
            .ToListAsync();
    }

    public async Task<Post?> AddPostAsync(Post post)
    {
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        return post;
    }

    public async Task<Post?> UpdatePostAsync(Post post)
    {
        var postToUpdate = await _context.Posts.FindAsync(post.Id);

        if (postToUpdate == null)
            return null;

        _context.Entry(postToUpdate).CurrentValues.SetValues(post);

        await _context.SaveChangesAsync();

        return post;
    }

    public async Task<Post?> DeletePostAsync(Guid id)
    {
        var postToDelete = await _context.Posts.FindAsync(id);

        if (postToDelete == null)
            return null;

        _context.Posts.Remove(postToDelete);
        await _context.SaveChangesAsync();
        return postToDelete;
    }
}