using Domain.Enums;

namespace Domain.Entities;

public class Question : BaseEntities
{
    public string? Text { get; set; }
    public QuestionType? Type { get; set; }
    
    //navigation
    public int? ExemId { get; set; }
    public Exem? Exem { get; set; }
}