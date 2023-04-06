using BusinessLayer.DTO.Employee;
using BusinessLayer.DTO.Shift;
using ShiftLoggerApp.Services;
using ShiftLoggerApp.Validation;


var api = new Client("http://localhost:5043/");
var employeeService = new EmployeeService(api);
var shiftService = new ShiftService(api);

while (true)
{
    DisplayService.DisplayMenu();
    int choice = int.Parse(Console.ReadLine()!);

    switch (choice)
    {
        case 1:
            DisplayService.DisplaySubMenu("Employee");
            await DoCrud(employeeService);
            break;
        case 2:
            DisplayService.DisplaySubMenu("Shift");
            await DoCrud(shiftService);
            break;
        case 3:
            await DisplayService.DisplayItems(employeeService, shiftService);
            break;
        case 4:
            break;
        case 5:
            return;
    }
}




async Task DoCrud<T>(ICrudService<T> service)
{
    var userInput = new UserInputValidator();
    int choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1:
            await PerformAdd(service, userInput);
            break;
        case 2:
            await PerformDelete(service);
            break;
        case 3:
            await PerformUpdate(service, userInput);
            break;
        case 4:
            return;
    }

    Console.ReadKey();
}

async Task PerformAdd<T>(ICrudService<T> service, UserInputValidator userInput)
{
    var item = await service.CreateServiceObject(userInput);
    await service.Add(item);
}

async Task PerformDelete<T>(ICrudService<T> service)
{
    Console.Write("Write an ID to delete: ");
    var objectId = int.Parse(Console.ReadLine());
    await service.Delete(objectId);
}

async Task PerformUpdate<T>(ICrudService<T> service, UserInputValidator userInput)
{
    Console.Write("Write an ID to update: ");
    var objectId = int.Parse(Console.ReadLine());
    var item = await service.CreateServiceObject(userInput);
    await service.Update(objectId, item);
}