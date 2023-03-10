using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.Dto;

public class ShiftRequestDTO
{
    public int ShiftId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    
    [ForeignKey("EmployeeId")]
    public int EmployeeId { get; set; }
}