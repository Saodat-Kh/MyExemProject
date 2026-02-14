using System.Net;
using Application.Dto.Lesson;
using Application.Interfaces;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Filter;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class LessonService(ApplicationDataContext context, IMapper mapper) : ILessonService
{
    public Response<string> CreateLesson(CreateLessonDto dto)
    {
        try
        {
            var map = mapper.Map<Lesson>(dto);
            context.Lessons.Add(map);
            var res = context.SaveChanges();
            return res > 0
                ? new Response<string>(HttpStatusCode.Created,"Lesson created successfully")
                : new Response<string>(HttpStatusCode.BadRequest, "Lesson creation failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, "Internal  Server Error");
        }
    }

    public Response<string> UpdateLesson(int id, UpdateLessonDto dto)
    {
        try
        {
            var res = context.Lessons.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            if(res == null)
                return new Response<string>(HttpStatusCode.NotFound, "Lesson not found");
            res.Title = dto.Title ?? res.Title;
            res.Content = dto.Content ?? res.Content;
            res.Order = dto.Order ?? res.Order;
            var rew = context.SaveChanges();
            return rew > 0
                ? new Response<string>(HttpStatusCode.OK, "Lesson updated successfully")
                : new Response<string>(HttpStatusCode.BadRequest,"Lesson updation failed");  
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, "Internal  Server Error");

        }
    }

    public Response<string> DeleteLesson(int id)
    {try
        {

            var res = context.Lessons.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            res.IsDeleted = true;
            res.DeletedAt = DateTime.UtcNow;
            var rew = context.SaveChanges();
            return rew > 0
                ? new Response<string>(HttpStatusCode.OK, "Lesson deleted successfully")
                : new Response<string>(HttpStatusCode.BadRequest, "Lesson deletion failed");

        }
        catch (Exception e)
        { 
            return new Response<string>(HttpStatusCode.InternalServerError, "Internal  Server Error");

        }
    }

    public async Task<PaginationResponses<List<GetLessonDto>>> GetAllLessons(LessonFilter filter)
    {try
        {

            var lesson = context.Lessons.AsQueryable();
            if (!string.IsNullOrEmpty(filter.Title))
            {
                lesson = lesson.Where(x => x.Title.Contains(filter.Title));
            }

            if (!string.IsNullOrEmpty(filter.Content))
            {
                lesson = lesson.Where(x => x.Content.Contains(filter.Content));
            }

            if (filter.Order.HasValue)
            {
                lesson = lesson.Where(x => x.Order >= filter.Order);
            }

            lesson = lesson.Where(x => x.IsDeleted == false);
            var total = lesson.Count();
            var skip = (filter.PageNumber - 1) * filter.PageSize;
            var lessons = await lesson.Skip(skip).Take(filter.PageSize).ToListAsync();
            if (lessons.Count() == 0)
                return new PaginationResponses<List<GetLessonDto>>(HttpStatusCode.OK, "Lessons not found");
            var map = mapper.Map<List<GetLessonDto>>(lessons);
            return new PaginationResponses<List<GetLessonDto>>(map, total, filter.PageNumber, filter.PageSize);

        }
        catch (Exception e)
        {
            return new PaginationResponses<List<GetLessonDto>>(HttpStatusCode.InternalServerError, "Internal  Server Error");

        }
    }

    public Response<GetLessonDto> GetLessonById(int id)
    {
        try
        {
            var res = context.Lessons.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            if(res == null)
                return new Response<GetLessonDto>(HttpStatusCode.NotFound,"Lesson not found");
            var map =  mapper.Map<GetLessonDto>(res);
            return new Response<GetLessonDto>(map);
        }
        catch 
        {
            return new Response<GetLessonDto>(HttpStatusCode.InternalServerError, "Internal  Server Error");

        }
    }
}