using Application.Dto.Exem;
using Application.Dto.Lesson;
using Application.Responses;

namespace Application.Interfaces;

public interface IExemService
{
    Response<string> CreateExem(CreateExemDto dto);
    Response<string> UpdateExem(int id, UpdateExemDto dto);
    Response<string> DeleteExem(int id);
    Response<List<GetExemDto>>  GetAllExems();
    Response<GetExemDto> GetExemById(int id);
}