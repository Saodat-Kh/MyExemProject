using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Exem> Exems { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<AnswerOption>  AnswerOptions { get; set; }
    public DbSet<StudentExemResult>     StudentResults { get; set; }
}