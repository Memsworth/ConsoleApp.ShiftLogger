using System.Text.Json.Serialization;
using BusinessLayer.Models;

namespace BusinessLayer.DTO.Employee;

public class EmployeeDTO
{
    [JsonPropertyName("employeeId")]
    public int EmployeeId { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("dateOfBirth")]
    public DateTime DateOfBirth { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }

}