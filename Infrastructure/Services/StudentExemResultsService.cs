using System.Net;
using Application.Dto.StudentExemResult;
using Application.Interfaces;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Filter;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentExemResultsService(ApplicationDataContext context, IMapper mapper) : IStudentExemResultService
{
    public async Task<PaginationResponses<List<GetStudentExemResultDto>>> GetAllStudentExemResults(StudentExemResultFilter filter)
    {
        try
        {
            var stuexares = context.StudentResults.Where(x=> x.IsDeleted == false).AsQueryable();
            if (filter.ExemId.HasValue)
            {
                stuexares = stuexares.Where(x=> x.ExemId == filter.ExemId);
            }

            if (filter.StudentId.HasValue)
            {
                stuexares = stuexares.Where(x => x.StudentId == filter.StudentId);
            }

            if (filter.Passed.HasValue)
            {
                stuexares = stuexares.Where(x => x.Passed == filter.Passed);
            }
            
            var total = stuexares.Count();
            var skip =  (filter.PageNumber - 1) * filter.PageSize;
            var students = await stuexares.Skip(skip).Take(filter.PageSize).ToListAsync();
            if(students.Count() == 0)
                return new PaginationResponses<List<GetStudentExemResultDto>>(HttpStatusCode.OK, "Student Exam Results Not Found");
            var map = mapper.Map<List<GetStudentExemResultDto>>(students);
            return new PaginationResponses<List<GetStudentExemResultDto>>(map,total,filter.PageSize,filter.PageNumber);
            
        }
        catch (Exception e)
        {
            return new PaginationResponses<List<GetStudentExemResultDto>>(HttpStatusCode.InternalServerError,"Internal Server Error");
        }
        
    }

    public Response<GetStudentExemResultDto> GetStudentExamResultById(int id)
    {
        var  res = context.StudentResults.FirstOrDefault(x => x.Id == id &&  x.IsDeleted == false);
        if(res == null)
            return new Response<GetStudentExemResultDto>(HttpStatusCode.NotFound," Student Result Not Found");
        var map = mapper.Map<GetStudentExemResultDto>(res);
        return new Response<GetStudentExemResultDto>(map);
    }

    public Response<string> CreateStudentExamResult(CreateStudentExemResultDto dto)
    {
        try
        {
            var map = mapper.Map<StudentExemResult>(dto);
            context.StudentResults.Add(map);
            var res =  context.SaveChanges();
            return res > 0
                ? new Response<string>(HttpStatusCode.Created,"Student Exem Results Created Successfully")
                : new Response<string>(HttpStatusCode.BadRequest,"Student Exem Results Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        }
    }

    public Response<string> UpdateStudentExamResult(int id, UpdateStudentExamResultDto dto)
    {
        try
        {
            var res = context.StudentResults.FirstOrDefault(x=> x.Id == id && x.IsDeleted == false);
            if (res == null)
                return new Response<string>(HttpStatusCode.NotFound," Student Result Not Found");
            res.Score = dto.Score ??  res.Score;
            res.Passed = dto.Passed ?? res.Passed;
            res.UpdatedAt = DateTime.UtcNow;
            var rew = context.SaveChanges();
            return rew > 0
                ? new Response<string>(HttpStatusCode.OK,"Student Exem Results Updated Successfully" )
                : new Response<string>(HttpStatusCode.BadRequest,"Student Exem Results Updated Failed");
        }
        catch 
        {
            return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        }
    }
}