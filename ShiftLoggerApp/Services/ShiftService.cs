using System.Net.Http.Json;
using System.Text.Json;
using BusinessLayer.DTO.Shift;
using ShiftLoggerApp.Validation;

namespace ShiftLoggerApp.Services;

public class ShiftService : ICrudService <ShiftPostDTO>
{
    public async Task Add(ShiftPostDTO serviceObject, Client httpClient)
    {
        var response = await httpClient.ApiClient.PostAsJsonAsync("api/Shifts", serviceObject);
        Console.WriteLine(response.IsSuccessStatusCode ? "ShiftAdded" : "Error can't add");
    }

    public async Task Delete(int serviceObjectId, Client httpClient)
    {
        var response = await httpClient.ApiClient.DeleteAsync($"api/Shifts/{serviceObjectId}");
        Console.WriteLine(response.IsSuccessStatusCode ? "Shift deleted" : "Error can't delete");
    }

    public async Task Update(int serviceObjectId, ShiftPostDTO serviceObject, Client httpClient)
    {
        var response = await httpClient.ApiClient.PutAsJsonAsync($"api/Shifts/{serviceObjectId}", serviceObject);
        Console.WriteLine(response.IsSuccessStatusCode ? "Shift updated" : "Error can't update");
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
    
    
    public async Task<List<ShiftDTO>?> Get(Client httpClient, string request)
    {
        var response = await httpClient.ApiClient.GetStreamAsync(request);
        var data =  await JsonSerializer.DeserializeAsync<List<ShiftDTO>?>(response);
        return data;
    }

}