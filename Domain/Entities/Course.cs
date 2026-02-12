using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;
using Domain.Enums;

namespace Domain.Entities;

public class Course : BaseEntities
{
    [Required]
    [StringLength(50),MinLength(3)]
    public required string Title { get; set; }
    public string Description { get; set; }
    public CourseLevel Level { get; set; }
    [Required]
    public required decimal Price { get; set; }
    
    
    //navigation
    public List<Lesson>?  Lessons { get; set; }
    public List<Exem>?   Exems { get; set; }
}