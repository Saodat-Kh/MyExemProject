using Application.Dto.Question;
using Application.Dto.StudentExemResult;
using Application.Responses;
using Domain.Filter;

namespace Application.Interfaces;

public interface IStudentExemResultService
{
   Task<PaginationResponses<List<GetStudentExemResultDto>>> GetAllStudentExemResults(StudentExemResultFilter filter);
   Response<GetStudentExemResultDto> GetStudentExamResultById(int id);
   Response<string> CreateStudentExamResult(CreateStudentExemResultDto dto);
   Response<string> UpdateStudentExamResult(int id,UpdateStudentExamResultDto dto);
}