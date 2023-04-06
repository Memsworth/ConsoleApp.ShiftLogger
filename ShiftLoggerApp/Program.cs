using BusinessLayer.DTO.Employee;
using ShiftLoggerApp.Services;
using ShiftLoggerApp.Validation;


var api = new Client("http://localhost:5043/");
var employeeService = new EmployeeService();
var shiftService = new ShiftService();

while (true)
{
    DisplayService.DisplayMenu();
    int choice = int.Parse(Console.ReadLine()!);

    switch (choice)
    {
        case 1:
            DisplayService.DisplaySubMenu("Employee");
            await DoCrud(api, employeeService);
            break;
        case 2:
            DisplayService.DisplaySubMenu("Shift");
            await DoCrud(api, shiftService);
            break;
        case 3:
            await DisplayItems(api, employeeService);
            break;
        case 4:
            break;
        case 5:
            return;
    }
}


async Task DisplayItems3<T>(Client http, ICrudService<T> service)
{
  int choice = int.Parse(Console.ReadLine());
  string requestUri;
  switch (choice)
    {
        case 1:
            requestUri = "api/Employee";
            break;
        case 2:
            Console.Write("Employee id you want to see: ");
            int empId = int.Parse(Console.ReadLine());
            requestUri = $"api/Employee/{empId}";
            break;
        case 3:
            requestUri = "api/Shifts";
            break;
        case 4:
            Console.Write("Shift id you want to see: ");
            int
        
    }
}

//async Task DisplayItems2(Client httpClient, ShiftService shift)
{
  //  var items = await shift.Get(httpClient, "api/Employee");
  //  DisplayService.DisplayTable(items, "shift table");
}
async Task DisplayItems(Client httpClient, EmployeeService employee)
{
    Console.WriteLine($"1 to display all, 2 to display by id");
    int choice = int.Parse(Console.ReadLine());
    List<EmployeeDTO> data = new List<EmployeeDTO?>();
    switch (choice)
    {
        case 1:
            data = await employee.Get<List<EmployeeDTO>>(httpClient, $"/api/Employee");
            DisplayService.DisplayTable(data, "Employee Data");
            break;
        case 2:
            Console.Write($"Enter EMP ID: ");
            var empId = int.Parse(Console.ReadLine());
            var data2 = await employee.Get<EmployeeDTO?>(httpClient, $"api/Employee/{empId}");
            data.Add(data2);
            DisplayService.DisplayTable(data, "Employee Data");
            break;
    }
}

async Task DoCrud<T>(Client httpClient, ICrudService<T> service)
{
    var userInput = new UserInputValidator();
    int choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1:
            await PerformAdd(httpClient, service, userInput);
            break;
        case 2:
            await PerformDelete(httpClient, service);
            break;
        case 3:
            await PerformUpdate(httpClient, service, userInput);
            break;
        case 4:
            return;
    }
}

async Task PerformAdd<T>(Client httpClient, ICrudService<T> service, UserInputValidator userInput)
{
    var item = await service.CreateServiceObject(userInput);
    await service.Add(item, httpClient);
}

async Task PerformDelete<T>(Client httpClient, ICrudService<T> service)
{
    Console.Write("Write an ID to delete: ");
    var objectId = int.Parse(Console.ReadLine());
    await service.Delete(objectId, httpClient);
}

async Task PerformUpdate<T>(Client httpClient, ICrudService<T> service, UserInputValidator userInput)
{
    Console.Write("Write an ID to update: ");
    var objectId = int.Parse(Console.ReadLine());
    var item = await service.CreateServiceObject(userInput);
    await service.Update(objectId, item, httpClient);
}