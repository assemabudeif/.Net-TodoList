using TodoList.DTOs;

namespace TodoList.Repositories;

public class AuthRepository(IConfiguration configuration, AppDbContext context) : IAuthRepository
{


    public async Task<RegisterDto> Register(RegisterDto registerDto)
    {
        await context.Users.AddAsync(registerDto.ToUser());
        await context.SaveChangesAsync();

        return registerDto;
    }
    
}