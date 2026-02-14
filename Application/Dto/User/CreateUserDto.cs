using Domain.Enums;

namespace Application.Dto.User;

public class CreateUserDto
{
    public UserRole  Role { get; set; }
    
    
    public string Email { get; set; }
    public  string FirstName { get; set; }
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Address { get; set; }= string.Empty;   
}