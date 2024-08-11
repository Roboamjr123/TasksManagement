using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataLibrary.Models
{
    public class Projects
    {
        [Key]
        public int Project_Id { get; set; }
        public string? Project_Name { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; } = DateTime.UtcNow;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        [JsonIgnore]
        public ICollection<Tasks>? Task { get; set; }
    }
}
