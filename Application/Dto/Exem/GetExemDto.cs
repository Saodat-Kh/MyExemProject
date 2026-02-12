namespace Application.Dto.Exem;

public class GetExemDto
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public int MaxScore { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
}