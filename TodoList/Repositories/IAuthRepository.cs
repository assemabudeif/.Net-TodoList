using TodoList.DTOs;
using TodoList.Model;

namespace TodoList.Repositories;

public interface IAuthRepository
{
    Task<User?> Register(User registerDto);
    Task<User?> Login(LoginDto loginDto);
}