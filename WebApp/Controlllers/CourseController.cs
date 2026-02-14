using Application.Dto.Course;
using Application.Interfaces;
using Domain.Filter;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controlllers;
[ApiController]
[Route("api/[controller]")]
public class CourseController(ICourseService service) : Controller
{
    [HttpPost]
    public IActionResult CreateCourse(CreateCourseDto dto)
    {
        var res =  service.CreateCourse(dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("Filter")]
    public async Task<IActionResult> GetAllCourses([FromQuery]CourseFilter filter)
    {
        var res = await service.GetAllCourses(filter);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("Id")]
    public IActionResult GetCourseById(int id)
    {
        var res = service.GetCourseById(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut]
    public IActionResult UpdateCourse(int id, UpdateCourseDto dto)
    {
        var res = service.UpdateCourse(id, dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete]
    public IActionResult DeleteCourse(int id)
    {
        var res = service.DeleteCourse(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("WithLessonById")]
    public IActionResult GetCourseWithLessonWithId(int id)
    {
        var res = service.GetCourseWithLessonWithId(id);
        return StatusCode(res.StatusCode, res);
    }
}