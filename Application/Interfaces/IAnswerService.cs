using Application.Dto.AnswerOption;
using Application.Responses;

namespace Application.Interfaces;

public interface IAnswerService
{
    Response<string> CreateAnswer(CreateAnswerDto dto);
    Response<string> UpdateAnswer(int id, UpdateAnswerDto dto);
    Response<string> DeleteAnswer(int id);
}