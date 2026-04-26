namespace TodoList.DTOs;

public class AuthResponseDto
{
    public int UserId { get; set; }
    public string UserName { get; set; }  = string.Empty;
    public string Email { get; set; }  = string.Empty;
    public string AccessToken { get; set; }  = string.Empty;
    public string? RefreshToken { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
}