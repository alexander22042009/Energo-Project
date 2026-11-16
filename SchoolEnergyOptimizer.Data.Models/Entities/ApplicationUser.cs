using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SchoolEnergyOptimizer.Data.Models.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    public DateTime CreatedOn { get; set; }

    public ICollection<Reading> RecordedReadings { get; set; } = new List<Reading>();
}
