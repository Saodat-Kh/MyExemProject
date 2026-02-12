namespace Domain.Entities;

public class AnswerOption : BaseEntities
{
    public string Text { get; set; }
    public bool IsCorrect  { get; set; } 
    
    //navigation
    public int? QuestionId { get; set; }
    public Question? Question { get; set; }
}