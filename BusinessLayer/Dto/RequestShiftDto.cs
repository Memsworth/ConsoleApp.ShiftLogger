
using System.ComponentModel.DataAnnotations.Schema;
using BusinessLayer.Models;

namespace BusinessLayer.Dto;

public class RequestShiftDto
{
    public int ShiftId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    
    [ForeignKey("EmployeeId")]
    public int EmployeeId { get; set; }

    
    
}