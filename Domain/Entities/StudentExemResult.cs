namespace Domain.Entities;

public class StudentExemResult : BaseEntities
{
    public int Score {get; set;}
    public bool Passed {get; set;}
    
    //navigation
    public int? StudentId { get; set; }
    public User? Student { get; set; }
    
    public int? ExemId { get; set; }
    public Exem? Exem { get; set; }
}