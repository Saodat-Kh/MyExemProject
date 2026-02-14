using System.Net;
using Application.Dto.User;
using Application.Interfaces;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Filter;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class UserService(ApplicationDataContext context,IMapper mapper) : IUserService
{
    public Response<string> CreateUser(CreateUserDto dto)
    {try
        {

            var map = mapper.Map<User>(dto);
            context.Users.Add(map);
            var res = context.SaveChanges();
            return res > 0
                ? new Response<string>(HttpStatusCode.Created, "User created")
                : new Response<string>(HttpStatusCode.BadRequest, "User creation failed");

        }
        catch (Exception e)
        {
           return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error");
        }
    }

    public Response<string> DeleteUser(int id)
    {
        try
        {
            var res = context.Users.FirstOrDefault(x => x.Id == id );
            res.IsDeleted = true;
            res.DeletedAt = DateTime.UtcNow;
            var res2 = context.SaveChanges();
            return res2 > 0
                ? new Response<string>(HttpStatusCode.OK, "User deleted")
                : new Response<string>(HttpStatusCode.BadRequest, "User deletion failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, "Internal  Server Error");
        }
    }

    public Response<string> UpdateUser(int id, UpdateUserDto dto)
    {
        try
        {
            var res = context.Users.FirstOrDefault(x => x.Id == id &&  x.IsDeleted == false);
            if (res == null)
                return new Response<string>(HttpStatusCode.NotFound, "User not found");
            res.FirstName = dto.FirstName ?? res.FirstName;
            res.LastName = dto.LastName ?? res.LastName;
            res.Email = dto.Email ?? res.Email;
            res.Address = dto.Address ?? res.Address;
            res.Age = dto.Age ?? res.Age;
            res.Role = dto.Role ?? res.Role;
            var res2 = context.SaveChanges();
            return res2 > 0
                ? new Response<string>(HttpStatusCode.OK, "User updated")
                : new Response<string>(HttpStatusCode.BadRequest, "User updation failed");
            
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, "Internal  Server Error");
        }
    }

    public async Task<PaginationResponses<List<GetUserDto>>> GetAllUsers(UserFilter filter)
    {
        var user = context.Users.AsQueryable();
        if (!string.IsNullOrEmpty(filter.FirstName))
        {
            user = user.Where(x => x.FirstName.Contains(filter.FirstName));
        }

        if (!string.IsNullOrEmpty(filter.LastName))
        {
            user = user.Where(x => x.LastName.Contains(filter.LastName));
        }

        if (!string.IsNullOrEmpty(filter.Email))
        {
            user =  user.Where(x => x.Email.Contains(filter.Email));
        }

        if (filter.Role.HasValue)
        {
            user = user.Where(x => x.Role == filter.Role);
        }

        if (filter.Age.HasValue)
        {
            user = user.Where(x => x.Age == filter.Age);
        }

        user = user.Where(x=> x.IsDeleted == false);
        var total = user.Count();
        var skip = (filter.PageNumber - 1) * filter.PageSize;
        var users = await user.Skip(skip).Take(filter.PageSize).ToListAsync();
        if(users.Count() == 0)
            return new PaginationResponses<List<GetUserDto>>(HttpStatusCode.OK,"User not  found");
        var map =  mapper.Map<List<GetUserDto>>(users);
        return new PaginationResponses<List<GetUserDto>>(map,total,filter.PageSize,filter.PageNumber);
    }

    public Response<GetUserDto> GetUserById(int id)
    {
        var res = context.Users.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        if(res == null)
            return new Response<GetUserDto>(HttpStatusCode.NotFound, "User not  found");
        var map = mapper.Map<GetUserDto>(res);
        return new Response<GetUserDto>(map);
    }
}