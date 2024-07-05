using Blog_API.Models;

namespace Blog_API.Repositories.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();

    Task<User?> GetByIdAsync(Guid id);

    Task<User?> GetByUsernameAsync(string username);

    Task<bool> ExistingByUsernameAsync(string username);

    Task<bool> ExistingbyEmailAsync(string email);

    Task<User?> AddUserAsync(User user);

    Task<User?> UpdateUserAsync(User user);

    Task<User?> DeleteUserAsync(Guid id);
}
