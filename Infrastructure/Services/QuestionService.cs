using System.Net;
using Application.Dto.Question;
using Application.Interfaces;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class QuestionService(ApplicationDataContext context, IMapper mapper) : IQuestionService
{
    public Response<string> CreateQuestion(CreateQuestionDto dto)
    {
        try
        {
            var map = mapper.Map<Question>(dto);
            context.Questions.Add(map);
            var res =context.SaveChanges();
            return res > 0
                ? new Response<string>(HttpStatusCode.Created, "Question created successfully")
                : new Response<string>(HttpStatusCode.BadRequest, "Question creation failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        }
    }

    public Response<string> UpdateQuestion(int id, UpdateQuestionDto dto)
    {
        try
        {
            var res = context.Questions.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            if(res == null)
                return new Response<string>(HttpStatusCode.NotFound,"Question not found");
            res.Text = dto.Text ??  res.Text;
            res.Type = dto.Type ??  res.Type;
            var rew = context.SaveChanges();
            return rew > 0
            ? new Response<string>(HttpStatusCode.OK, "Question updated successfully")
            : new Response<string>(HttpStatusCode.BadRequest, "Question updation failed");
        }
        catch (Exception e)
        {
           return new Response<string>(HttpStatusCode.InternalServerError," Internal Server Error");
        }
    }

    public Response<string> DeleteQuestion(int id)
    {
        try
        {
            var res = context.Questions.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            res.IsDeleted = true;
            res.DeletedAt = DateTime.UtcNow;
            var rew = context.SaveChanges();
            return rew > 0
            ? new Response<string>(HttpStatusCode.OK, "Question deleted successfully")
            : new  Response<string>(HttpStatusCode.BadRequest, "Question deletion failed");
        }
        catch 
        {
            return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        }
    }

    public Response<List<GetQuestionDto>> GetAllQuestions(int exemId)
    {
        try
        {
            var res = context.Questions.Where(x => x.ExemId == exemId && x.IsDeleted == false).ToList();
            var map = mapper.Map<List<GetQuestionDto>>(res);
            return new Response<List<GetQuestionDto>>(map);
        }
        catch (Exception e)
        {
            return new Response<List<GetQuestionDto>>(HttpStatusCode.InternalServerError, " Internal Server Error");
        }
    }
}