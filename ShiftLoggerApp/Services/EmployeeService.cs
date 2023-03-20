using System.Net.Http.Json;
using BusinessLayer.Dto;

namespace ShiftLoggerApp.Services;

public class EmployeeService 
{
    public async Task AddEmployee(BusinessLayer.Dto.EmployeeUpdateDTO employeeDTO, Client httpClient)
    { 
        var response = await httpClient.ApiClient.PostAsJsonAsync("api/Employee", employeeDTO);
        Console.WriteLine(response.IsSuccessStatusCode ? "Item inserted" : "Error to post");
    }
    public async Task DeleteEmployee(int id, Client httpClient)
    {
        var response = await httpClient.ApiClient.DeleteAsync($"api/Employee/{id}");
        Console.WriteLine(response.IsSuccessStatusCode ? "Item deleted" : "Error to delete");
    }

    public void UpdateEmployee()
    {
        
    }

    public void GetEmployee()
    {
        
    }
}