// See https://aka.ms/new-console-template for more information

using BusinessLayer.DTO.Shift;

Console.WriteLine("Hello, World!");

async Task<ShiftPostDTO> MakeShift(int empId)
{
    return new ShiftPostDTO()
    {
        StartTime = DateTime.Now,
        EndTime = null,
        EmployeeId = empId
    };
}