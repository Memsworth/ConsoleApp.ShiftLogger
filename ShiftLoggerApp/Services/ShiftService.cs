using System.Net.Http.Json;
using BusinessLayer.DTO.Shift;

namespace ShiftLoggerApp.Services;

public class ShiftService
{
    public async Task AddShift(ShiftPostDTO shiftDTO, Client httpClient)
    {
        var response = await httpClient.ApiClient.PostAsJsonAsync("api/Shifts", shiftDTO);
        Console.WriteLine(response.IsSuccessStatusCode ? "ShiftAdded" : "Error can't add");
    }


    public async Task DeleteShift(int id, Client httpClient)
    {
        var response = await httpClient.ApiClient.DeleteAsync($"api/Shifts/{id}");
        Console.WriteLine(response.IsSuccessStatusCode ? "Shift deleted" : "Error can't delete");
    }


    public async Task UpdateShift(ShiftUpdateDto shiftDTO, int id, Client httpClient)
    {
        var response = await httpClient.ApiClient.PutAsJsonAsync($"api/Shifts/{id}", shiftDTO);
        Console.WriteLine(response.IsSuccessStatusCode ? "Shift updated" : "Error can't update");
    }

    public void GetShift()
    {
        
    }
}