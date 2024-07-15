using Blog_API.Context;
using Blog_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog_API.Repositories.Implementation;

public class UserRepository(BlogContext context) : IUserRepository
{
    private readonly BlogContext _context = context;

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
    }

    public async Task<bool> ExistingByUsernameAsync(string username)
    {
        return await _context.Users.AnyAsync(u => u.UserName == username);
    }

    public async Task<bool> ExistingbyEmailAsync(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }

    public async Task<User?> AddUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> UpdateUserAsync(User user)
    {
        var userToUpdate = await _context.Users.FindAsync(user.Id);

        if (userToUpdate == null)
            return null;

        _context.Entry(userToUpdate).CurrentValues.SetValues(user);

        await _context.SaveChangesAsync();
        return userToUpdate;
    }

    public async Task<User?> DeleteUserAsync(Guid id)
    {
        var userToRemove = await _context.Users.FindAsync(id);

        if (userToRemove == null)
            return null;

        _context.Users.Remove(userToRemove);
        await _context.SaveChangesAsync();
        return userToRemove;
    }
}