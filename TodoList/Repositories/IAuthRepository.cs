namespace TodoList.Repositories;

public interface IAuthRepository
{
        Task<DTOs.RegisterDto> Register(DTOs.RegisterDto registerDto);
}