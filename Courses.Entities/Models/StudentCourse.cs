namespace Courses.Entities.Models;

public class StudentCourse
{
    public virtual Guid CourseId { get; set; }
    public virtual Course Course { get; set; }

    public virtual Guid StudentId { get; set; }
    public virtual Student Student { get; set; }

    public string Feedback { get; set; }
}