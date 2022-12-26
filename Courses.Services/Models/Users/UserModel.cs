using Courses.Entities.Models;

namespace Courses.Services.Models;

public class UserModel : BaseModel
{
    public string PasswordHash { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
}