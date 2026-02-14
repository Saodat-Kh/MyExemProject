using Domain.Enums;

namespace Domain.Filter;

public class CourseFilter : BaseFilter
{
    public string? Title { get; set; }
    public CourseLevel?  Level { get; set; }
    public decimal? Price { get; set; }
}