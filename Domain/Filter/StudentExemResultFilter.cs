namespace Domain.Filter;

public class StudentExemResultFilter : BaseFilter
{
    public int? StudentId { get; set; }
    public int? ExemId { get; set; }
    public bool? Passed { get; set; }
}