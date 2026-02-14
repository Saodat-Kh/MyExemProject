using Application.Dto.Course;
using Application.Dto.Lesson;
using Application.Responses;
using Domain.Filter;

namespace Application.Interfaces;

public interface ICourseService
{
    Response<string> CreateCourse(CreateCourseDto dto);
    Response<string> UpdateCourse(int id, UpdateCourseDto dto);
    Response<string> DeleteCourse(int id);
    Task<PaginationResponses<List<GetCourseDto>>> GetAllCourses(CourseFilter filter);
    Response<GetCourseDto> GetCourseById(int id);
    Response<GetCourseDto> GetCourseWithLessonWithId(int id);

}