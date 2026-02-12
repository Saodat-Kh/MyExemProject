using Domain.Enums;

namespace Application.Dto.Course;

public class UpdateCourseDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public CourseLevel? Level { get; set; }
    public decimal? Price { get; set; }
}