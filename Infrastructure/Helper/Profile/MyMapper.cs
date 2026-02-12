using Application.Dto.AnswerOption;
using Application.Dto.Course;
using Application.Dto.Exem;
using Application.Dto.Lesson;
using Application.Dto.Question;
using Application.Dto.StudentExemResult;
using Application.Dto.User;
using Domain.Entities;

namespace Infrastructure.Helper.Profile;

public class MyMapper : AutoMapper.Profile 
{
    public MyMapper() 
    {
        CreateMap<User,CreateStudentWithPagination>().ReverseMap();
        CreateMap<Course, CreateCourseDto>().ReverseMap();
        CreateMap<Lesson, CreateLessonDto>().ReverseMap();
        CreateMap<Exem, CreateExemDto>().ReverseMap();
        CreateMap<Question, CreateQuestionDto>().ReverseMap();
        CreateMap<AnswerOption, CreateAnswerDto>().ReverseMap();
        CreateMap<StudentExemResult, CreateStudentExemResultDto>().ReverseMap();
    }
}