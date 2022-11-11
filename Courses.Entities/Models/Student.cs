namespace Courses.Entities.Models;

public class Student : BaseEntity 
{
    public Guid UserId { get; set; }

    public string AccountNumber { get; set; }

    public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    public virtual ICollection<StudyingLecture> StudyingLectures { get; set; }
}