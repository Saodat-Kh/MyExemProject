namespace Application.Dto.Lesson;

public class GetLessonDto
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty; 
    public string Content { get; set; }
    public int Order { get; set; }
    public DateTime? CreatedAt { get; set; }  = DateTime.UtcNow;
}