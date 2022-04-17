using System.ComponentModel.DataAnnotations;

namespace BlogSN.Backend.Models;
public class Post
{
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Content { get; set; }
    
    public DateTime? DateCreated { get; set; }
    
    public ICollection<Category>? Categories { get; set; }
    public int? UserId { get; set; }
    
    public User? User { get; set; }


}