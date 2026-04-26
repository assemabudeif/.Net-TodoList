using TodoList.DTOs;

namespace TodoList.Services;

public interface IAuthService
{
    public Task<AuthResponseDto?> Register(RegisterDto registerDto);
    public Task<AuthResponseDto?> Login(LoginDto loginDto);
}