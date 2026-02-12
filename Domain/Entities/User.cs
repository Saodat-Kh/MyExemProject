using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities;

public class User : BaseEntities
{
    [Required]
    public required string FirstName { get; set; }

    [StringLength(50), MinLength(3)] 
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    [StringLength(50),MinLength(3)]
    public string Address { get; set; }= string.Empty;
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    public UserRole Role { get; set; }
    
    //navigation
    public List<Exem>? Exems { get; set; }
    
}