using System.Text.Json.Serialization;

namespace BusinessLayer.DTO.Shift;

public class ShiftDTO
{
    [JsonPropertyName("shiftId")]
    public int ShiftId { get; set; }
    [JsonPropertyName("startTime")]
    public DateTime StartTime { get; set; }
    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; set; }
    [JsonPropertyName("employeeId")]
    public int EmployeeId { get; set; }
}