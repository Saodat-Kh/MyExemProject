using Application.Dto.User;
using Application.Responses;
using Domain.Filter;

namespace Application.Interfaces;

public interface IUserService
{
    Response<string> CreateUser(CreateUserDto dto);
    Response<string> DeleteUser(int id);
    Response<string> UpdateUser(int id, UpdateUserDto dto);
    Task<PaginationResponses<List<GetUserDto>>> GetAllUsers(UserFilter filter);
    Response<GetUserDto> GetUserById(int id);
}