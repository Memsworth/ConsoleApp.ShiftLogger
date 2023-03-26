namespace BusinessLayer.DTO.Shift;

public class ShiftDTO
{
    public int ShiftId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int EmployeeId { get; set; }
}