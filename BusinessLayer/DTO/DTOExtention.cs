using BusinessLayer.DTO.Employee;

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
    }
}
