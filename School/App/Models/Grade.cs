namespace App.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public string CourseName { get; set; }
        public decimal GradeNum { get; set; }
    }
}