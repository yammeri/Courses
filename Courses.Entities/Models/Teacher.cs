namespace Courses.Entities.Models;

public class Teacher : BaseEntity
{
    public Guid UserId { get; set; }

    public virtual ICollection<Course> Courses { get; set; }
}