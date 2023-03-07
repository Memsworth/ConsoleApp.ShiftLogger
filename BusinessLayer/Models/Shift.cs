using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BusinessLayer.Models;

public class Shift
{
    public int ShiftId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    
    [NotMapped]
    public TimeSpan? Duration => EndTime.HasValue ? EndTime.Value - StartTime : (TimeSpan?)null;
    
    [ForeignKey("EmployeeId")]
    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }

}