using System.Net.Http.Json;
using System.Text.Json;
using BusinessLayer.DTO.Employee;
using ShiftAdminApp.Validation;

namespace ShiftAdminApp.Services;

public class EmployeeService : ICrudService<EmployeePostDTO>
{
    private readonly Client _client;

    public EmployeeService(Client client)
    {
        _client = client;
    }
    
    public async Task Add(EmployeePostDTO serviceObject)
    {
        var response = await _client.ApiClient.PostAsJsonAsync("api/Employee", serviceObject);
        Console.WriteLine(response.IsSuccessStatusCode ? "Item inserted" : "Error to post");
    }

    public async Task Delete(int serviceObjectId)
    {
        var response = await _client.ApiClient.DeleteAsync($"api/Employee/{serviceObjectId}");
        Console.WriteLine(response.IsSuccessStatusCode ? "Item deleted" : "Error to delete");
    }

    public async Task Update(int serviceObjectId, EmployeePostDTO serviceObject)
    {
        var newRequest = await _client.ApiClient.PutAsJsonAsync($"api/Employee/{serviceObjectId}", serviceObject);
        Console.WriteLine(newRequest.IsSuccessStatusCode ? "item updated": "error in update");
    }

    public async Task<T> Get<T>(string requestUri)
    {
        var request = await _client.ApiClient.GetStringAsync($"{requestUri}");
        var data = JsonSerializer.Deserialize<T>(request);
        return data;
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