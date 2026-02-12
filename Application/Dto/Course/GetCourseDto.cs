using Domain.Enums;

namespace Application.Dto.Course;

public class GetCourseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public CourseLevel Level { get; set; }
    public required decimal Price { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
}