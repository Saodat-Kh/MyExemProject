using Domain.Enums;

namespace Application.Dto.Question;

public class GetQuestionDto
{
    public int Id { get; set; }
    public string Text { get; set; }
    public QuestionType Type { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
}