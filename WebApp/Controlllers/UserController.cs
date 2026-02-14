using Application.Dto.User;
using Application.Interfaces;
using Domain.Filter;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controlllers;
[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService service) : Controller 
{
    [HttpPost]
    public IActionResult CreateUser(CreateUserDto dto)
    {
        var res = service.CreateUser(dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("Filter")]
    public async Task<IActionResult> GetAllUsers([FromQuery] UserFilter filter)
    {
        var res = await service.GetAllUsers(filter);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("Id")]
    public IActionResult GetUserById(int id)
    {
        var res = service.GetUserById(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut]
    public IActionResult UpdateUser(int id, UpdateUserDto dto)
    {
        var res = service.UpdateUser(id, dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete]
    public IActionResult DeleteUser(int id)
    {
        var res = service.DeleteUser(id);
        return StatusCode(res.StatusCode, res);
    }
}
