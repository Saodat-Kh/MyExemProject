namespace Application.Dto.StudentExemResult;

public class CreateStudentExemResultDto
{
    
    public int Score {get; set;}
    public int ExemId { get; set; }
    public int? StudentId { get; set; }
}