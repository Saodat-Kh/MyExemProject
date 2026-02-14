using Application.Dto.Lesson;
using Application.Interfaces;
using Domain.Filter;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controlllers;
[ApiController]
[Route("api/[controller]")]
public class LessonController(ILessonService service) : Controller
{
    [HttpPost]
    public IActionResult CreateLesson(CreateLessonDto dto)
    {
        var res = service.CreateLesson(dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("Filter")]
    public async Task<IActionResult> GetAllLessons([FromQuery]LessonFilter filter)
    {
        var res = await service.GetAllLessons(filter);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("id")]
    public IActionResult GetLessonById(int id)
    {
        var res = service.GetLessonById(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut]
    public IActionResult UpdateLesson(int id, UpdateLessonDto dto)
    {
        var res = service.UpdateLesson(id, dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete]
    public IActionResult DeleteLesson(int id)
    {
        var res = service.DeleteLesson(id);
        return StatusCode(res.StatusCode, res);
    }
    
}