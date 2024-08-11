using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataLibrary.Models
{
    public class SubTasks
    {
        [Key]
        public int SubT_Id { get; set; }
        public string? SubT_Name { get; set; }
        public DateTime? PlannedStartDate { get; set; } = DateTime.UtcNow;
        public DateTime? PlannedEndDate { get; set; } = DateTime.UtcNow;
        public DateTime? ActualStartDate { get; set; } = DateTime.UtcNow;
        public DateTime? ActualEndDate { get; set; } = DateTime.UtcNow;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;


        [ForeignKey("Task")]
        public int Task_Id { get; set; }

        [JsonIgnore]
        public Tasks? Task { get; set; }

        [JsonIgnore]
        public ICollection<SubDetails>? SubDetail { get; set; }
    }
}
