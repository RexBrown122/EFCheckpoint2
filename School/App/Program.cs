using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Data;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DataContext();

            // Returning a list of students
            Console.WriteLine("\nList of all students:");
            db.Student.ToList().ForEach(student => Console.WriteLine($"Student Name: {student.FirstName} {student.LastName}"));

            // Returning students and their grades
            Console.WriteLine("\nStudents and their grades:");
            var students = db.Student.Where(x => x.Id < 6).Select(x => new { Name=x.FirstName , Grades=x.GradesList}).ToList();
            students.ForEach(x =>
            {
                StringBuilder hold = new StringBuilder();
                x.Grades.ToList().ForEach(grade => hold.Append(grade.GradeNum + " "));
                Console.WriteLine($"Student {x.Name} Has Grades {hold.ToString(0,hold.Length)}");
            });

            // Returning students and their AVG grades
            Console.WriteLine("\nFind each students' average grade:");
            var queryAvgGrade = db.Student.OrderByDescending(val => val.GradesList.Average(val => (int)val.GradeNum));
            queryAvgGrade.ToList().ForEach(student => {
                if(student.GradesList != null){
                    Console.WriteLine($"{student.FirstName}'s average grade is {student.GradesList.Average(val => (int)val.GradeNum)}");
                }
                else{
                    Console.WriteLine($"{student.FirstName} has no courses.");
                }
            });

            // Returning the student with the highest AVG
            Console.WriteLine("\nFind the student with the highest average.");
            var queryHighestAvg = db.Student.OrderByDescending(val => val.GradesList.Average(val => (int)val.GradeNum)).FirstOrDefault();
            Console.WriteLine($"{queryHighestAvg.FirstName} has the highest average: {queryHighestAvg.GradesList.Average(val => (int)val.GradeNum)}");

            // Student with the most courses

            // Student that has ZERO courses
            Console.WriteLine("\nStudent That Has Zero Courses:");
            var studentWithNoCourses = db.Student.Where(x => x.GradesList.Count == 0).FirstOrDefault();
            if (studentWithNoCourses != null)
                Console.WriteLine(
                    $"Student {studentWithNoCourses.FirstName} {studentWithNoCourses.LastName} Has NO Courses");
            

            // Total number of Freshmen
            Console.WriteLine("\nFreshman Count:");
            var freshmenCount = db.Student.Where(student => student.ClassYear.Equals(Classification.Freshman)).ToList().Count();
            Console.WriteLine($"Total number of Freshmen: {freshmenCount}");

            // AVG grade of all Sophomores

            Console.WriteLine();
        }
    }
}
