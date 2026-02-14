using Application.Dto.Lesson;
using Application.Responses;
using Domain.Filter;

namespace Application.Interfaces;

public interface ILessonService
{
    Response<string>  CreateLesson(CreateLessonDto dto);
    Response<string> UpdateLesson(int id, UpdateLessonDto dto);
    Response<string> DeleteLesson(int id);
    Task<PaginationResponses<List<GetLessonDto>>> GetAllLessons(LessonFilter filter);
    Response<GetLessonDto> GetLessonById(int id);
    
}