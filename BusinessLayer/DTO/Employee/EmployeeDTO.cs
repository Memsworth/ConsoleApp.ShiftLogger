using BusinessLayer.Models;

namespace BusinessLayer.DTO.Employee;

public class EmployeeDTO
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }

}