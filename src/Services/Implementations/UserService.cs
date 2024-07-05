using Blog_API.Context;
using Blog_API.Models;
using Blog_API.Models.Enums;
using Blog_API.Repositories.Interfaces;
using Blog_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog_API.Services.Implementations;

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public bool ValidateRole(string role)
    {
        return Enum.TryParse(typeof(EnumUser), role, out _);
    }

    public bool ValidatePassword(string passwordhash, string passwordSalt)
    {
        if (passwordhash.Equals(passwordSalt))
            return true;

        return false;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<User?> CreatedUserAsync(User user)
    {
        if (ValidateRole(user.Role.ToString()) == false)
            return null;

        if (ValidatePassword(user.PasswordHash, user.PasswordSalt) == false)
            return null;

        return await _userRepository.AddUserAsync(user);
    }

    public async Task<User?> UpdateUserAsync(User user)
    {
        if (ValidateRole(user.Role.ToString()) == false)
            return null;

        if(ValidatePassword(user.PasswordHash, user.PasswordSalt) == false)
            return null;
    
        return await _userRepository.UpdateUserAsync(user);
    }

    public Task<User?> RemoveUserAsync(Guid id)
    {
        return _userRepository.DeleteUserAsync(id);
    }
}