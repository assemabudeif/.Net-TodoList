using Microsoft.EntityFrameworkCore;
using TodoList.DTOs;
using TodoList.Model;

namespace TodoList.Repositories;

public class AuthRepository(AppDbContext context) : IAuthRepository
{


    public async Task<User> Register(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        return user;
    }

    public async Task<User?> Login(LoginDto loginDto)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
        return user;
    }
}