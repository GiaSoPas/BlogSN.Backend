using System.ComponentModel.DataAnnotations;

namespace BlogSN.Backend.Models;

public class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public DateTime? DateOfBirthday { get; set; }

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    public string Password { get; set; }
    
    public int? RoleId { get; set; }
    
    public Role Role { get; set; }
    
    public IList<Post>? Posts { get; set; }
}