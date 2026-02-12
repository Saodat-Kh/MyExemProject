using System.ComponentModel.DataAnnotations;

namespace Application.Dto.Lesson;

public class CreateLessonDto
{
    public required string Title { get; set; }
    [Required]
    public required string Content { get; set; }
    public int Order { get; set; }
}