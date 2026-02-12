using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Lesson : BaseEntities
{
    [Required]
    public required string Title { get; set; }
    [Required]
    public required string Content { get; set; }
    public int Order { get; set; }
    
    //navigation
    public int? CourseId { get; set; }
    public Course? Course { get; set; }
}