namespace Courses.Entities.Models;

public class Subject : BaseEntity 
{
    public Guid SubjectId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Course> Courses { get; set; }
}