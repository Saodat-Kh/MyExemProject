namespace Domain.Entities;

public class Exem : BaseEntities
{
    public string Title { get; set; } = String.Empty;
    public int MaxScore { get; set; }
    
    //navigation
    public int? CourseId { get; set; }
    public Course? Course { get; set; }
    
    public List<Question>?  Questions { get; set; }
    
    public List<User>?  Users { get; set; }
}