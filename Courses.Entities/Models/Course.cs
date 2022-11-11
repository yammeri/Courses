namespace Courses.Entities.Models;

public class Course 
{
    public virtual Guid SubjectId { get; set; }
    public virtual Subject Subject { get; set; }

    public virtual Guid TeacherId { get; set; }
    public virtual Teacher Teacher { get; set; }

    public Guid CourseId { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public float Rating { get; set; }
    public string Description { get; set; }
    public TimeSpan StudyingTime { get; set; }

    public virtual ICollection<Lecture> Lectures { get; set; }
    public virtual ICollection<StudentCourse> StudentCourses { get; set; }
}