using BusinessLayer.DTO.Employee;
using BusinessLayer.DTO.Shift;

namespace BusinessLayer.DTO
{
    public static class DTOExtention
    {
        public static EmployeeDTO ToDto(this BusinessLayer.Models.Employee employee) => new EmployeeDTO
        {
            EmployeeId = employee.EmployeeId,
            Name = employee.Name,
            DateOfBirth = employee.DateOfBirth,
            Email = employee.Email
        };

        public static Models.Employee ToDbo(this BusinessLayer.DTO.Employee.EmployeePostDTO employeePostDto) =>
            new Models.Employee()
            {
                Name = employeePostDto.Name,
                DateOfBirth = employeePostDto.DateOfBirth,
                Email = employeePostDto.Email
            };

        public static void UpdateItems(this BusinessLayer.Models.Employee employee,
            EmployeePostDTO employeeDto)
        {
            employee.Name = employeeDto.Name;
            employee.DateOfBirth = employeeDto.DateOfBirth;
            employee.Email = employeeDto.Email;
        }
        
        public static ShiftDTO ToDto(this BusinessLayer.Models.Shift shift) => new ShiftDTO()
        {
            ShiftId = shift.ShiftId,
            StartTime = shift.StartTime,
            EndTime = shift.EndTime,
            EmployeeId = shift.EmployeeId
        };
        
        public static Models.Shift ToDbo(this BusinessLayer.DTO.Shift.ShiftPostDTO shiftDto) =>
            new Models.Shift()
            {
                StartTime = shiftDto.StartTime,
                EndTime = shiftDto.EndTime,
                EmployeeId = shiftDto.EmployeeId
            };

        public static void UpdateItem(this BusinessLayer.Models.Shift shift, ShiftUpdateDto shiftDto)
        {
            shift.StartTime = shiftDto.StartTime;
            shift.EndTime = shiftDto.EndTime;
        }
    }
}
