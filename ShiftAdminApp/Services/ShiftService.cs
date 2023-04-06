using System.Net.Http.Json;
using System.Text.Json;
using BusinessLayer.DTO.Shift;
using ShiftAdminApp.Validation;

namespace ShiftAdminApp.Services;

public class ShiftService : ICrudService <ShiftPostDTO>
{
    private readonly Client _client;
    public ShiftService(Client client)
    {
        _client = client;
    }
    
    public async Task Add(ShiftPostDTO serviceObject)
    {
        var response = await _client.ApiClient.PostAsJsonAsync("api/Shifts", serviceObject);
        Console.WriteLine(response.IsSuccessStatusCode ? "ShiftAdded" : "Error can't add");
    }

    public async Task Delete(int serviceObjectId)
    {
        var response = await _client.ApiClient.DeleteAsync($"api/Shifts/{serviceObjectId}");
        Console.WriteLine(response.IsSuccessStatusCode ? "Shift deleted" : "Error can't delete");
    }

    public async Task Update(int serviceObjectId, ShiftPostDTO serviceObject)
    {
        var response = await _client.ApiClient.PutAsJsonAsync($"api/Shifts/{serviceObjectId}", serviceObject);
        Console.WriteLine(response.IsSuccessStatusCode ? "Shift updated" : "Error can't update");
    }

    public async Task<T> Get<T>(string requestUri)
    {
        var request = await _client.ApiClient.GetStringAsync($"{requestUri}");
        var data = JsonSerializer.Deserialize<T>(request);
        return data;
    }

    public async Task<ShiftPostDTO> CreateServiceObject(UserInputValidator userInputService)
    {
        var startTime = userInputService.GetInput("Enter a start time", userInputService.GetValidShift);
        var endTime = userInputService.GetInput("Enter a end time", userInputService.GetValidShift);
        Console.WriteLine("Enter an id");
        var employeeId = int.Parse(Console.ReadLine());

        return new ShiftPostDTO()
        {
            StartTime = DateTime.Parse(startTime),
            EndTime = DateTime.Parse(endTime),
            EmployeeId = employeeId
        };
    }
    
}