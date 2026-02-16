namespace Application.Dto.StudentCourse;

public class GetStudentCourseDto
{
    public int StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<GetStudentCourseDto>  Courses { get; set; }
}