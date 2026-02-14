namespace Application.Dto.AnswerOption;

public class GetAnswerOptionDto
{
    public int Id { get; set; }
    public string Text { get; set; }
    public bool IsCorrect  { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}