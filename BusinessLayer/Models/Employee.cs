namespace BusinessLayer.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Email { get; set; }
    public IEnumerable<Shift> Shifts { get; set;}
}