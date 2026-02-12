using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Application.Dto.User;

public class UpdateUserDto
{
    
    public  string? FirstName { get; set; } 
    public string? LastName { get; set; } = string.Empty;
    public int? Age { get; set; }
    public string? Address { get; set; }= string.Empty;
    [EmailAddress]
    public  string? Email { get; set; }
    public UserRole? Role { get; set; }
}