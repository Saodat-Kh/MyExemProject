using Application.Dto.AnswerOption;
using Application.Dto.Course;
using Application.Dto.Exem;
using Application.Dto.Lesson;
using Application.Dto.Question;
using Application.Dto.StudentCourse;
using Application.Dto.StudentExemResult;
using Application.Dto.User;
using Domain.Entities;

namespace Infrastructure.Helper.Profile;

public class MyMapper : AutoMapper.Profile 
{
    public MyMapper() 
    {
        CreateMap<User,CreateUserDto>().ReverseMap();
        CreateMap<User, GetUserDto>().ReverseMap();
        CreateMap<Course, CreateCourseDto>().ReverseMap();
        CreateMap<Course,GetCourseDto>().ReverseMap();
        CreateMap<Lesson, CreateLessonDto>().ReverseMap();
        CreateMap<Lesson, GetLessonDto>().ReverseMap();
        CreateMap<Exem, CreateExemDto>().ReverseMap();
        CreateMap<Exem, GetExemDto>().ReverseMap();
        CreateMap<Question, CreateQuestionDto>().ReverseMap();
        CreateMap<Question, GetQuestionDto>().ReverseMap();
        CreateMap<AnswerOption, CreateAnswerOptionDto>().ReverseMap();
        CreateMap<AnswerOption,GetAnswerOptionDto>().ReverseMap();
        CreateMap<StudentExemResult, CreateStudentExemResultDto>().ReverseMap();
        CreateMap<StudentExemResult, GetStudentExemResultDto>().ReverseMap();
        CreateMap<Course, GetStudentCourseDto>().ReverseMap();
        CreateMap<User, GetStudentCourseSummaryDto>().ReverseMap();
    }
}