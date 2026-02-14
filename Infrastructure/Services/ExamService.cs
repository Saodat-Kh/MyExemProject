using System.Net;
using Application.Dto.Exem;
using Application.Dto.Lesson;
using Application.Interfaces;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class ExamService(ApplicationDataContext context,IMapper mapper) : IExemService
{
    public Response<string> CreateExem(CreateExemDto dto)
    {
        try
        {
            var map = mapper.Map<Exem>(dto);
            context.Exems.Add(map);
            var res = context.SaveChanges();
            return res > 0
                ? new Response<string>(HttpStatusCode.Created,"Exem created successfully")
                : new Response<string>(HttpStatusCode.BadRequest, " Exem creation failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        }
    }

    public Response<string> UpdateExem(int id, UpdateExemDto dto)
    {
        try
        {
            var res = context.Exems.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            if (res == null) 
                return new Response<string>(HttpStatusCode.NotFound, "Exem not found");
            res.Title = dto.Title ??  res.Title;
            res.MaxScore = dto.MaxScore ??  res.MaxScore;
            var rew = context.SaveChanges();
            return rew > 0
                ? new Response<string>(HttpStatusCode.OK, "Exem updated successfully")
                : new Response<string>(HttpStatusCode.BadRequest, " Exem updation failed");

        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError," Internal Server Error");
        }
    }

    public Response<string> DeleteExem(int id)
    {
        try
        {
            var res = context.Exems.FirstOrDefault(x => x.Id == id );
            res.IsDeleted = true;
            res.DeletedAt = DateTime.UtcNow;
            var rew = context.SaveChanges();
            return rew > 0
                ? new Response<string>(HttpStatusCode.OK, "Exem deleted successfully")
                : new Response<string>(HttpStatusCode.BadRequest, " Exem deletion failed");
        }
        catch (Exception e)
        {
           return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        }
    }

    public Response<List<GetExemDto>> GetAllExems()
    {
        try
        {
            var res = context.Exems.ToList();
            var map = mapper.Map<List<GetExemDto>>(res);
            return new Response<List<GetExemDto>>(map);
        }
        catch (Exception e)
        {
            return new Response<List<GetExemDto>>(HttpStatusCode.InternalServerError,"Internal Server Error");
        }
    }

    public Response<GetExemDto> GetExemById(int id)
    {
        var res = context.Exems.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        var map = mapper.Map<GetExemDto>(res);
        return new Response<GetExemDto>(map);
    }
}