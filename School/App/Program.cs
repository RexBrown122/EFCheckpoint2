using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Data;
using Microsoft.EntityFrameworkCore;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DataContext();

            var student1 = db.Student.Where(x => x.Id < 6).Select(x => new { Name=x.FirstName , Grades=x.GradesList}).ToList();
            student1.ForEach(x =>
            {
                StringBuilder hold = new StringBuilder();
                x.Grades.ToList().ForEach(grade => hold.Append(grade.GradeNum + " "));
                Console.WriteLine($"Student {x.Name} Has Grades {hold.ToString(0,hold.Length)}");
            });
            

        }
    }
}
