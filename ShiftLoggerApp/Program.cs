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
            break;
        case 4:
            break;
        case 5:
            return;
    }
}

async Task DoCrud<T>(Client httpClient, ICrudService<T> service)
{
    int choice = int.Parse(Console.ReadLine());
    int objectId;
    T item;
    
    switch (choice)
    {
        case 1:
            item = await service.CreateServiceObject(new UserInputValidator());
            await service.Add(item, httpClient);
            break;
        case 2:
            Console.Write("Write an ID to delete: ");
            objectId = int.Parse(Console.ReadLine());
            await service.Delete(objectId, httpClient);
            break;
        case 3:
            Console.Write("Write an ID to update: ");
            objectId = int.Parse(Console.ReadLine());
            item = await service.CreateServiceObject(new UserInputValidator());
            await service.Update(objectId, item, httpClient);
            break;
        case 4:
            return;
    }
}