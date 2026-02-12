using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Application.Dto.Course;

public class CreateCourseDto
{
    [Required]
    [StringLength(50),MinLength(3)]
    public required string Title { get; set; }
    public string Description { get; set; }
    public CourseLevel Level { get; set; }
    [Required]
    public required decimal Price { get; set; }
}