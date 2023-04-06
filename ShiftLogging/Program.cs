using BusinessLayer.DTO.Shift;
using ShiftLogging.Services;

var api = new ApiClient("http://localhost:5043/");
var shiftService = new ShiftService(api);

while (true)
{
    DisplayService.DisplayMenu();
    int choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1:
            await StartShift();
            break;
        case 2:
            await EndShift();
            break;
        default:
            Console.WriteLine("wrong input");
            break;
    }
}

async Task EndShift()
{
    Console.Write("Enter your employee ID: ");
    int empId = int.Parse(Console.ReadLine());
    var data = await shiftService.GetByEmp(empId);
    if (data is null)
    {
        Console.WriteLine("No active shift");
        return;
    }
    
    var item = data.OrderDescending().First();
    if (item.EndTime != null)
    {
        Console.WriteLine("Error SHIFT ENDED");
        return;
    }

    var shiftUpdate = new ShiftUpdateDto()
    {
        StartTime = item.StartTime,
        EndTime = DateTime.Now
    };

    await shiftService.Update(shiftUpdate, item.ShiftId);
}

async Task StartShift()
{
    Console.Write("Enter your employee ID: ");
    int empId = int.Parse(Console.ReadLine());
    var currentShift = await MakeShift(empId);
    var data = await shiftService.GetByEmp(empId);
    if (data is null)
    {
        await shiftService.Add(currentShift);
        return;
    }
    //check if shit has empty space
    var item = data.OrderDescending().First();
    if (item.EndTime == null)
    {
        Console.WriteLine("ERROR, You are already in a shift");
        return;
    }

    await shiftService.Add(currentShift);
}

async Task<ShiftPostDTO> MakeShift(int empId)
{
    return new ShiftPostDTO()
    {
        StartTime = DateTime.Now,
        EndTime = null,
        EmployeeId = empId
    };
}