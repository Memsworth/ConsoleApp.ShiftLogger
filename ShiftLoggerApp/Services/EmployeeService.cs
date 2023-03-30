using System.Net.Http.Json;
using BusinessLayer.DTO.Employee;

namespace ShiftLoggerApp.Services;

public class EmployeeService 
{
    
    public async Task AddEmployee(EmployeePostDTO employeeDTO, Client httpClient)
    { 
        var response = await httpClient.ApiClient.PostAsJsonAsync("api/Employee", employeeDTO);
        Console.WriteLine(response.IsSuccessStatusCode ? "Item inserted" : "Error to post");
    }
    public async Task DeleteEmployee(int id, Client httpClient)
    {
        var response = await httpClient.ApiClient.DeleteAsync($"api/Employee/{id}");
        Console.WriteLine(response.IsSuccessStatusCode ? "Item deleted" : "Error to delete");
    }

    public async Task UpdateEmployee(EmployeePostDTO employeeDTO, int id, Client httpClient)
    {
        var newRequest = await httpClient.ApiClient.PutAsJsonAsync($"api/Employee/{id}", employeeDTO);
        Console.WriteLine(newRequest.IsSuccessStatusCode ? "item updated": "error in update");
    }

    public void GetEmployee()
    {
        
    }
}