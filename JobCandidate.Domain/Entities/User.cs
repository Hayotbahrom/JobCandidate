using System.ComponentModel.DataAnnotations;

namespace JobCandidate.Domain.Entities;

public class User
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PreferedTime { get; set; }
    public string? LinkedIdProfileUrl { get; set; }
    public string? GitHubProfileUrl { get; set; }
    [Required]
    public string Comment { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
