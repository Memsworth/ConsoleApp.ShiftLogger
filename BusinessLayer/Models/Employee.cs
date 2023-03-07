namespace BusinessLayer.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public IEnumerable<Shift> Shifts { get; set;}
}