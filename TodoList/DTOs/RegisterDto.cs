using System.ComponentModel.DataAnnotations;
using TodoList.Model;

namespace TodoList.DTOs;

public class RegisterDto
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    [MinLength(6)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    public User ToUser()
    {
        return new User
        {
            Name = this.Name,
            Email = this.Email,
            Password = this.Password
        };
    }
}