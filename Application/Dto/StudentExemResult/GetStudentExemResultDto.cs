using Domain.Entities;

namespace Application.Dto.StudentExemResult;

public class GetStudentExemResultDto
{
    public int Id { get; set; }
    public int Score {get; set;}
    public bool Passed {get; set;}
    public int StudentId { get; set; }
    public int ExemId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  
}