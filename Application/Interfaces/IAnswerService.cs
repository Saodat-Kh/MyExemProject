using Application.Dto.AnswerOption;
using Application.Responses;

namespace Application.Interfaces;

public interface IAnswerService
{
    Response<string> CreateAnswer(CreateAnswerOptionDto optionDto);
    Response<string> UpdateAnswer(int id, UpdateAnswerOptionDto optionDto);
    Response<string> DeleteAnswer(int id);
}