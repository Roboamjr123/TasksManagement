using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataLibrary.Models
{
    public class SubDetails
    {
        [Key]
        public int SubD_Id { get; set; }
        public string? SubD_Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        [ForeignKey("SubTask")]
        public int SubT_Id { get; set; }

        [JsonIgnore]
        public SubTasks? SubTask { get; set; }
    }
}
