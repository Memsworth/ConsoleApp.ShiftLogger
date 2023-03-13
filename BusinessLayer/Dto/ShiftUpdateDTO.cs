namespace BusinessLayer.Dto;

public class ShiftUpdateDTO
{
    public int ShiftId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}