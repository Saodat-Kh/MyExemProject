using Application.Dto.StudentCourse;
using Application.Responses;

namespace Application.Interfaces;

public interface IStudentCourseSummaryService
{
    Response<GetStudentCourseSummaryDto> GetStudentCourseSummary(int id);
}