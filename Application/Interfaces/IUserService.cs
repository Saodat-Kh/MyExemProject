using Application.Dto.User;
using Application.Responses;

namespace Application.Interfaces;

public interface IUserService
{
    Response<string> CreateUser(CreateStudentWithPagination dto);
    Response<string> DeleteUser(int id);
    Response<string> UpdateUser(int id, UpdateUserDto dto);
    Response<List<GetUserDto>> GetAllUsers();
    Response<GetUserDto> GetUserById(int id);
}