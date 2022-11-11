namespace Courses.Entities.Models;

public class Lecture 
{
    public virtual Guid CourseId { get; set; }
    public virtual Course Course { get; set; }

    public Guid LectureId { get; set; }
    public string Topic { get; set; }
    public TimeSpan StudyingTime { get; set; }

    public virtual ICollection<StudyingLecture> StudyingLectures { get; set; }
}