using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TodoList.DTOs;
using TodoList.Model;
using TodoList.Repositories;

namespace TodoList.Services;

public class AuthService(IConfiguration config, IAuthRepository repo) : IAuthService
{
    public async Task<AuthResponseDto?> Register(RegisterDto registerDto)
    {
        var user = await repo.Register(new User
        {
            Name = registerDto.Name,
            Email = registerDto.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password)
        });

        if (user == null) return null;

        var token = GenerateToken(user);
        var response = new AuthResponseDto
        {
            AccessToken = token,
            UserId = user.Id,
            Name = user.Name,
            Email = user.Email
        };

        return response;
    }

    public async Task<AuthResponseDto?> Login(LoginDto loginDto)
    {
        var user = await repo.Login(loginDto);
        if (user == null) return null;
        var token = GenerateToken(user);
        var response = new AuthResponseDto
        {
            AccessToken = token,
            UserId = user.Id,
            Name = user.Name,
            Email = user.Email
        };
        return response;
    }

    private string GenerateToken(User user)
    {
        // Implement JWT token generation logic here
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(config["Jwt:Key"]!));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Name)
        };

        var token = new JwtSecurityToken(
            config["Jwt:Issuer"],
            config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);


        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}