using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Grade> Grade { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=app.db");
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var Students = new Student[] {
                new Student { Id = 1, FirstName = "Mark", LastName = "Flores", Age = 15, ClassYear = Classification.Freshman },
                new Student { Id = 2, FirstName = "John", LastName = "Doe", Age = 16, ClassYear = Classification.Sophomore },
                new Student { Id = 3, FirstName = "Jessica", LastName = "Robinson", Age = 17, ClassYear = Classification.Junior },
                new Student { Id = 4, FirstName = "Rex", LastName = "Brown", Age = 18, ClassYear = Classification.Senior },
                new Student { Id = 5, FirstName = "Amanda", LastName = "Johnson", Age = 18, ClassYear = Classification.Senior }
            };

            var Grades = new Grade[] {
                new Grade { Id = 1, StudentId = 1, CourseName = "English", GradeNum = 80 },
                new Grade { Id = 2, StudentId = 2, CourseName = "Math", GradeNum = 60 },
                new Grade { Id = 3, StudentId = 3, CourseName = "Science", GradeNum = 75 },
                new Grade { Id = 4, StudentId = 4, CourseName = "Government", GradeNum = 90 },
                new Grade { Id = 5, StudentId = 2, CourseName = "English", GradeNum = 100 }
            };

            builder.Entity<Student>().HasData(Students);
            builder.Entity<Grade>().HasData(Grades);
            base.OnModelCreating(builder);
        }
    }
}