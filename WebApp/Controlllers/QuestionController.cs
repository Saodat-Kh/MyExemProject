using Application.Dto.Question;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controlllers;
[ApiController]
[Route("api/[controller]")]
public class QuestionController(IQuestionService service) : Controller
{
    [HttpGet]
    public IActionResult GetAllQuestions(int exemId)
    {
        var questions = service.GetAllQuestions(exemId);
        return StatusCode(questions.StatusCode, questions);
    }

    [HttpPost]
    public IActionResult CCreateQuestion(CreateQuestionDto dto)
    {
        var res = service.CreateQuestion(dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut]
    public IActionResult UpdateQuestion(int id, UpdateQuestionDto dto)
    {
        var res = service.UpdateQuestion(id, dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete]
    public IActionResult DeleteQuestion(int id)
    {
        var res = service.DeleteQuestion(id);
        return StatusCode(res.StatusCode, res);
    }
}