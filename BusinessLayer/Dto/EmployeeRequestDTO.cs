namespace BusinessLayer.Dto;

public class EmployeeRequestDTO
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
}