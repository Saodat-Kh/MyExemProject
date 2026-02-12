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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Course>().HasMany(x=> x.Lessons).WithOne(x=> x.Course).HasForeignKey(x => x.CourseId);
        modelBuilder.Entity<Course>().HasMany(x=> x.Exems).WithOne(z => z.Course).HasForeignKey(x => x.CourseId);
        modelBuilder.Entity<Exem>().HasMany(x=> x.Questions).WithOne(z=> z.Exem).HasForeignKey(c=>c.ExemId);
        modelBuilder.Entity<Question>().HasMany(z=> z.AnswerOptions).WithOne(z=> z.Question).HasForeignKey(z=>z.QuestionId);
        modelBuilder.Entity<User>().HasMany(x=> x.StudentExemResults).WithOne(c=> c.Student).HasForeignKey(c=>c.StudentId);
        modelBuilder.Entity<Exem>().HasMany(x=> x.StudentExemResults).WithOne(c=> c.Exem).HasForeignKey(c=>c.ExemId);
    }

 
}