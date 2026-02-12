using Domain.Enums;

namespace Application.Dto.Question;

public class CreateQuestionDto
{
    public string? Text { get; set; }
    public QuestionType? Type { get; set; }

}