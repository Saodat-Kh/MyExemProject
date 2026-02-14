using Application.Dto.Exem;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controlllers;
[ApiController]
[Route("api/[controller]")]
public class ExemController(IExemService service) : Controller
{
    [HttpPost]
    public IActionResult CreateExem(CreateExemDto dto)
    {
        var res = service.CreateExem(dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet]
    public IActionResult GetAllExems()
    {
        var res = service.GetAllExems();
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("id")]
    public IActionResult GetExemById(int id)
    {
        var res = service.GetExemById(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut]
    public IActionResult UpdateExem(int id, UpdateExemDto dto)
    {
        var res = service.UpdateExem(id, dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete]
    public IActionResult DeleteExem(int id)
    {
        var res = service.DeleteExem(id);
        return StatusCode(res.StatusCode, res);
    }
    
}