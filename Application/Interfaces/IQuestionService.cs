using Application.Dto.Lesson;
using Application.Dto.Question;
using Application.Responses;

namespace Application.Interfaces;

public interface IQuestionService
{
   Response<string> CreateQuestion(CreateQuestionDto dto);
   Response<string> UpdateQuestion(int id, UpdateQuestionDto dto);
   Response<string> DeleteQuestion(int id);
   Response<List<GetQuestionDto>>  GetAllQuestions(int exemId);
}