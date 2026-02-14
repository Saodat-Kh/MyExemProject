namespace Domain.Filter;

public class LessonFilter : BaseFilter
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public int? Order { get; set; }
}