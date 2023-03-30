//using BusinessLayer.Dto;
using ShiftLoggerApp.Services;
Console.WriteLine("Hello, World!");

bool appEnd = false;
var api = new Client("http://localhost:5043/");
//var employeeService = new EmployeeService();


while (!appEnd)
{
    DisplayService.DisplayMenu();
    int choice = int.Parse(Console.ReadLine()!);

    switch (choice)
    {
        case 1:
            DisplayService.DisplaySubMenu("Employee");
            //await EmployeeCrud(employeeService, api);
            break;
        case 2:
            DisplayService.DisplaySubMenu("Shift");
            break;
        case 3:
            StartShift();
            break;
        case 4:
            break;
        case 5:
            return;
    }
}

void StartShift()
{
    
}
/*async Task EmployeeCrud(EmployeeService employeeService, Client httpClient)
{
    Console.WriteLine("This employee CRUD Choose");
    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            var employeeToAdd = makeEmployeeDTO(new UserInputService());
            await employeeService.AddEmployee(employeeToAdd, httpClient);
            break;
        case 2:
            Console.WriteLine("employee to delete id: ");
            var empoyeeId = int.Parse(Console.ReadLine());
            await employeeService.DeleteEmployee(empoyeeId, httpClient);
            break;
        case 3:
            Console.WriteLine("employee id to update: ");
            var employeeId = int.Parse(Console.ReadLine());
            var editEmp = makeEmployeeDTO(new UserInputService());
            await employeeService.UpdateEmployee(editEmp, employeeId, httpClient);
            break;
        case 4:
            break;
    }
}*/

/*EmployeeUpdateDTO makeEmployeeDTO(UserInputService userInputService)
{
    var name = userInputService.GetInput("Enter a name", userInputService.GetValidName);
    Console.WriteLine("enterdob");
    var dateOfBirth = Console.ReadLine();
    var email = userInputService.GetInput("Enter an email", userInputService.GetValidEmail);

    return new EmployeeUpdateDTO()
    {
        DateOfBirth = DateTime.Parse(dateOfBirth),
        Email = email,
        Name = name
    }; 
}*/