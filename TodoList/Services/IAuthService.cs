using TodoList.DTOs;

namespace TodoList.Services;

public interface IAuthService
{
    public Task<DTOs.AuthResponseDto> Register(DTOs.RegisterDto registerDto);
    public Task<AuthResponseDto?> Login(DTOs.LoginDto loginDto);
}