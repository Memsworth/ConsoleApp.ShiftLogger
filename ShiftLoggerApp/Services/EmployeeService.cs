using System.Net.Http.Json;
using BusinessLayer.DTO.Employee;
using BusinessLayer.DTO.Shift;
using ShiftLoggerApp.Validation;

namespace ShiftLoggerApp.Services;

public class EmployeeService : ICrudService<EmployeePostDTO>
{
    public async Task Add(EmployeePostDTO serviceObject, Client httpClient)
    {
        var response = await httpClient.ApiClient.PostAsJsonAsync("api/Employee", serviceObject);
        Console.WriteLine(response.IsSuccessStatusCode ? "Item inserted" : "Error to post");
    }

    public async Task Delete(int serviceObjectId, Client httpClient)
    {
        var response = await httpClient.ApiClient.DeleteAsync($"api/Employee/{serviceObjectId}");
        Console.WriteLine(response.IsSuccessStatusCode ? "Item deleted" : "Error to delete");
    }

    public async Task Update(int serviceObjectId, EmployeePostDTO serviceObject, Client httpClient)
    {
        var newRequest = await httpClient.ApiClient.PutAsJsonAsync($"api/Employee/{serviceObjectId}", serviceObject);
        Console.WriteLine(newRequest.IsSuccessStatusCode ? "item updated": "error in update");
    }

    public void Get(EmployeePostDTO serviceObject, Client httpClient)
    {
        throw new NotImplementedException();
    }

    public async Task<EmployeePostDTO> CreateServiceObject(UserInputValidator userInputService)
    {
        var name = userInputService.GetInput("Enter a name", userInputService.GetValidName);
        Console.Write("enter dob: ");
        var dateOfBirth = Console.ReadLine();
        var email = userInputService.GetInput("Enter an email", userInputService.GetValidEmail);

        return new EmployeePostDTO()
        {
            DateOfBirth = DateTime.Parse(dateOfBirth),
            Email = email,
            Name = name
        };
    }
}