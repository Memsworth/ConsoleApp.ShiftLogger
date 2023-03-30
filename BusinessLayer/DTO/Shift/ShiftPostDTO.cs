namespace BusinessLayer.DTO.Shift;

public class ShiftPostDTO
{
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int EmployeeId { get; set; }
}