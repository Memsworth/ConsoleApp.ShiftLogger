using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.Models;

public sealed class Shift
{
    public int ShiftId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }

    [ForeignKey("EmployeeId")]
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}