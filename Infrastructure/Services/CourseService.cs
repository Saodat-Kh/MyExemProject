using System.Net;
using Application.Dto.Course;
using Application.Dto.Lesson;
using Application.Interfaces;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Filter;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CourseService(ApplicationDataContext context,IMapper mapper) : ICourseService
{
    public Response<string> CreateCourse(CreateCourseDto dto)
    {try
        {

            var map = mapper.Map<Course>(dto);
            context.Courses.Add(map);
            var res = context.SaveChanges();
            return res > 0
                ? new Response<string>(HttpStatusCode.Created, "Course created successfully")
                : new Response<string>(HttpStatusCode.BadRequest, "Bad request");

        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error");
        }
    }

    public Response<string> UpdateCourse(int id, UpdateCourseDto dto)
    {
        try
        {
            var res = context.Courses.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            if (res == null)
                return new Response<string>(HttpStatusCode.NotFound, "Course not found");
            res.Title = dto.Title ??  res.Title;
            res.Description = dto.Description ??  res.Description;
            res.Price = dto.Price ??  res.Price;
            res.Level = dto.Level ??  res.Level;
            var rew = context.SaveChanges();
            return rew > 0
                ? new Response<string>(HttpStatusCode.OK, "Course updated successfully")
                : new  Response<string>(HttpStatusCode.BadRequest, "Bad request");
        }
        catch
        {
            return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error");
        }
    }

    public Response<string> DeleteCourse(int id)
    {try
        {

            var res = context.Courses.FirstOrDefault(x => x.Id == id );
            res.IsDeleted = true;
            res.DeletedAt = DateTime.UtcNow;
            var res2 = context.SaveChanges();
            return res2 > 0
                ? new Response<string>(HttpStatusCode.OK, "Course deleted successfully")
                : new Response<string>(HttpStatusCode.BadRequest, "Bad request, Course deletion failed");

        }
        catch (Exception e)
        {
           return new Response<string>(HttpStatusCode.InternalServerError, "Internal  Server Error");
        }
    }

    public async Task<PaginationResponses<List<GetCourseDto>>> GetAllCourses(CourseFilter filter)
    {try
        {

            var course = context.Courses.AsQueryable();
            if (!string.IsNullOrEmpty(filter.Title))
            {
                course = course.Where(x => x.Title.Contains(filter.Title));
            }

            if (filter.Level.HasValue)
            {
                course = course.Where(x => x.Level == filter.Level);
            }

            if (filter.Price.HasValue)
            {
                course = course.Where(x => x.Price == filter.Price);
            }

            course = course.Where(x => x.IsDeleted == false);
            var total = course.Count();
            var skip = (filter.PageNumber - 1) * filter.PageSize;
            var courses = await course.Skip(skip).Take(filter.PageSize).ToListAsync();
            if (courses.Count() == 0)
                return new PaginationResponses<List<GetCourseDto>>(HttpStatusCode.OK, "Course not found");
            var map = mapper.Map<List<GetCourseDto>>(courses);
            return new PaginationResponses<List<GetCourseDto>>(map, total, filter.PageNumber, filter.PageSize);

        }
        catch 
        {
            return new PaginationResponses<List<GetCourseDto>>(HttpStatusCode.InternalServerError, "Internal Server Error");
        }
    }

    public Response<GetCourseDto> GetCourseById(int id)
    {
        try
        {
            var res = context.Courses.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            if (res == null) 
                return new Response<GetCourseDto>(HttpStatusCode.NotFound, "Course not found");
            var map =  mapper.Map<GetCourseDto>(res);
            return new Response<GetCourseDto>(map);
        }
        catch
        {
           return new Response<GetCourseDto>(HttpStatusCode.InternalServerError, "Internal Server Error");   
        }
    }

    public Response<GetCourseDto> GetCourseWithLessonWithId(int id)
    {try
        {

            var res = context.Courses.Where(x => x.Id == id && x.IsDeleted == false)
                .Select(z => new GetCourseDto()
                {
                    Id = z.Id,
                    Title = z.Title,
                    Description = z.Description,
                    Price = z.Price,
                    Level = z.Level,
                    CreatedAt = z.CreatedAt,
                    UpdatedAt = z.UpdatedAt,
                    Lessons = z.Lessons.Where(x => x.IsDeleted == false).Select(z => new GetLessonDto()
                    {
                        Id = z.Id,
                        Title = z.Title,
                        Order = z.Order,
                        Content = z.Content,
                        CreatedAt = z.CreatedAt
                    }).ToList()
                }).FirstOrDefault();
            if (res == null)
                return new Response<GetCourseDto>(HttpStatusCode.NotFound, "Course not  found");
                return new Response<GetCourseDto>(res);
        }
        catch 
        {
            return new Response<GetCourseDto>(HttpStatusCode.InternalServerError, "Internal Server Error");
        }
    }
}