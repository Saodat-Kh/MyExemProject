using Application.Dto.Course;
using Application.Dto.Lesson;
using Application.Responses;

namespace Application.Interfaces;

public interface ICourseService
{
    Response<string> CreateCourse(CreateCourseDto dto);
    Response<string> UpdateCourse(int id, UpdateCourseDto dto);
    Response<string> DeleteCourse(int id);
    Response<List<GetCourseDto>> GetAllCourses();
    Response<GetCourseDto> GetCourseById(int id);
    Response<GetCourseDto> GetCourseWithLessonWithId(int id);

}