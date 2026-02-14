namespace Application.Dto.Lesson;

public class UpdateLessonDto
{
    public string? Title { get; set; } 
    public string? Content { get; set; }
    public int? Order { get; set; }
}