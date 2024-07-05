using Blog_API.Models;

namespace Blog_API.Services.Interfaces;

public interface IUserService
{

    bool ValidateRole(string role);

    bool ValidatePassword(string passwordHash, string passwordSalt);

    Task<List<User>> GetAllUsersAsync();

    Task<User?> GetUserByIdAsync(Guid id);

    Task<User?> CreatedUserAsync(User user);

    Task<User?> UpdateUserAsync(User user);

    Task<User?> RemoveUserAsync(Guid id);
}