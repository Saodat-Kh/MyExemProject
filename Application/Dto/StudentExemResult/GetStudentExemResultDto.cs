using Domain.Entities;

namespace Application.Dto.StudentExemResult;

public class GetStudentExemResultDto
{
    public int Score {get; set;}
    public bool Passed {get; set;}
    
    //navigation
    public int StudentId { get; set; }
    public Domain.Entities.User Student { get; set; }
    
    public int ExemId { get; set; }
    public Domain.Entities.Exem? Exem { get; set; }
}