using System.Net;
using Application.Dto.AnswerOption;
using Application.Interfaces;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class AnswerService(ApplicationDataContext context,IMapper mapper) : IAnswerService
{
    public Response<string> CreateAnswer(CreateAnswerOptionDto optionDto)
    {
        try
        {
            var map = mapper.Map<AnswerOption>(optionDto);
            context.AnswerOptions.Add(map);
            var res = context.SaveChanges();
            return res > 0
                ? new Response<string>(HttpStatusCode.Created,"Answer created")
                : new Response<string>(HttpStatusCode.BadRequest, " An error occured");
        }
        catch 
        {
            return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        }
    }

    public Response<string> UpdateAnswer(int id, UpdateAnswerOptionDto optionDto)
    {try
        {

            var res = context.AnswerOptions.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            if (res == null)
                return new Response<string>(HttpStatusCode.NotFound, " An error occured");
            res.Text = optionDto.Text ?? res.Text;
            res.IsCorrect = optionDto.IsCorrect ?? res.IsCorrect;
            var rew = context.SaveChanges();
            return rew > 0
                ? new Response<string>(HttpStatusCode.OK, "Answer updated")
                : new Response<string>(HttpStatusCode.BadRequest, " An error occured");


        }
        catch (Exception e)
        {
           return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        }
    }

    public Response<string> DeleteAnswer(int id)
    {try
        {

            var res = context.AnswerOptions.FirstOrDefault(x => x.Id == id);
            res.IsDeleted = true;
            res.DeletedAt = DateTime.UtcNow;
            var rew = context.SaveChanges();
            return rew > 0
                ? new Response<string>(HttpStatusCode.OK, "Answer deleted")
                : new Response<string>(HttpStatusCode.BadRequest, " An error occured");

        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        }
    }
}