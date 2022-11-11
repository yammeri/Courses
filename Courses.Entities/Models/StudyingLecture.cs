namespace Courses.Entities.Models;

public class StudyingLecture 
{
    public virtual Guid LectureId { get; set; }
    public virtual Lecture Lecture { get; set; }

    public virtual Guid StudentId { get; set; }
    public virtual Student Student { get; set; }

    public bool IsCompleted { get; set; }
}