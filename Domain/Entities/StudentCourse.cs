namespace Domain.Entities;

public class StudentCourse
{
    public int StudentId { get; set; }
    public User? User { get; set; }
    public int CourseId { get; set; }
    public Course? Course { get; set; }
}