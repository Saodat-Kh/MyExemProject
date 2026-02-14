using Application.Dto.AnswerOption;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controlllers;
[ApiController]
[Route("api/[controller]")]
public class AnswerOptionController(IAnswerService service) : Controller
{
    [HttpPost]
    public IActionResult CreateAnswer(CreateAnswerOptionDto optionDto)
    {
        var res = service.CreateAnswer(optionDto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut]
    public IActionResult UpdateAnswer(int id, UpdateAnswerOptionDto optionDto)
    {
        var res = service.UpdateAnswer(id, optionDto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete]
    public IActionResult DeleteAnswer(int id)
    {
        var res = service.DeleteAnswer(id);
        return StatusCode(res.StatusCode, res);
    }
}