using Application.Dto.Lesson;
using Application.Responses;

namespace Application.Interfaces;

public interface ILessonService
{
    Response<string>  CreateLesson(CreateLessonDto dto);
    Response<string> UpdateLesson(int id, UpdateLessonDto dto);
    Response<string> DeleteLesson(int id);
    Response<List<GetLessonDto>> GetAllLessons();
    Response<GetLessonDto> GetLessonById(int id);
    
}