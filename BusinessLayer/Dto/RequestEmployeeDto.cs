using BusinessLayer.Models;

namespace BusinessLayer.Dto;

public class RequestEmployeeDto
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    
    public RequestEmployeeDto(Employee employee)
    {
        EmployeeId = employee.EmployeeId;
        Name = employee.Name;
        DateOfBirth = employee.DateOfBirth;
        Email = employee.Email;
    }
}