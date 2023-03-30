using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.Models;

public class Shift
{
    public int ShiftId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }

    [ForeignKey("EmployeeId")]
    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }
}