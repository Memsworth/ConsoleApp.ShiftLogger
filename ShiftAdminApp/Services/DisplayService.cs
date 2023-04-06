using BusinessLayer.DTO.Employee;
using BusinessLayer.DTO.Shift;
using ConsoleTableExt;

namespace ShiftAdminApp.Services;

public class DisplayService
{
    public static async Task DisplayItems(EmployeeService employee, ShiftService shift)
    { 
        DisplayService.DisplayPrintMenu();
        int choice = int.Parse(Console.ReadLine());
        var employeeData = new List<EmployeeDTO?>();
        var shiftData = new List<ShiftDTO?>();
        
        //POKEMON CATCH EM ALL fix later
        try
        {
            string requestUri;
            int id;
            switch (choice) 
            { 
                case 1: 
                    requestUri = "api/Employee"; 
                    employeeData = await employee.Get<List<EmployeeDTO>>(requestUri); 
                    DisplayTable(employeeData, "DATA"); 
                    break;
                case 2: 
                    Console.Write("Employee id you want to see: "); 
                    id = int.Parse(Console.ReadLine()); 
                    requestUri = $"api/Employee/{id}"; 
                    var data = await employee.Get<EmployeeDTO?>(requestUri); 
                    employeeData.Add(data); 
                    DisplayTable(employeeData, "DATA"); 
                    break;
                case 3: 
                    requestUri = "api/Shifts"; 
                    shiftData = await shift.Get<List<ShiftDTO>?>(requestUri); 
                    DisplayTable(shiftData, "DATA"); 
                    break;
                case 4: 
                    Console.Write("Shift id you want to see: "); 
                    id = int.Parse(Console.ReadLine()); 
                    requestUri = $"api/Shifts/{id}"; 
                    var data2 = await shift.Get<ShiftDTO?>(requestUri); 
                    shiftData.Add(data2); 
                    DisplayTable(shiftData, "DATA"); 
                    break;
                default: 
                    Console.WriteLine("Wrong pick"); 
                    return;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    
        Console.ReadKey();
    }
    
    private static void DisplayTable<T>(List<T>? data, string tableName) where T : class?
    {
        ConsoleTableBuilder.From(data).WithTitle(tableName).ExportAndWriteLine();
    }

    private record DisplayMenuItem(string Id, string Value);

    private static void DisplayPrintMenu()
    {
        var tableData = new List<DisplayMenuItem>()
        {
            new("1", "All Employees"),
            new("2", "Employee by ID"),
            new("3", "All Shifts"),
            new("4", "Shift by ID")
        };
        DisplayTable(tableData, "DataPrintMenu");
    }
    public static void DisplaySubMenu(string title)
    {
        var tableData = new List<DisplayMenuItem>
        {
            new("1", "add"),
            new("2", "Edit/Update"),
            new("3", "Delete"),
            new("4", "Back")
        };
        DisplayTable(tableData, title);
    }
    
    public static void DisplayMenu()
    {
        var tableData = new List<DisplayMenuItem>
        {
            new("1", "Employees"),
            new("2", "Shifts"),
            new("3", "Display"),
            new("4", "start Shift"),
            new("5", "Exit"),
        };

        DisplayTable(tableData, "Main menu");
    }
}