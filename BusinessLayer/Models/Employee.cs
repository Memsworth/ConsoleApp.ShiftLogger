using System.Text.Json.Serialization;

namespace BusinessLayer.Models;

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
   
    [JsonIgnore]
    public virtual ICollection<Shift> Shifts { get; set; } = new HashSet<Shift>();
    
}