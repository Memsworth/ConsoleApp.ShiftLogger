using System.Net.Http.Json;
using System.Text.Json;
using BusinessLayer.DTO.Shift;

namespace ShiftLogging.Services;

public class ShiftService
{
    private readonly ApiClient _apiClient;
    public ShiftService(ApiClient apiClient) => _apiClient = apiClient;

    public async Task Add(ShiftPostDTO postItem)
    {
        var response = await _apiClient.Api.PostAsJsonAsync("api/Shifts", postItem);
        Console.WriteLine(response.IsSuccessStatusCode ? "Shift started" : "Error can't add");
    }

    public async Task Update(ShiftUpdateDto shiftUpdate, int id)
    {
        var response = await _apiClient.Api.PutAsJsonAsync($"api/Shifts/{id}", shiftUpdate);
        Console.WriteLine(response.IsSuccessStatusCode ? "Shift updated" : "Error can't update");
    }

    public async Task<List<ShiftDTO>?> GetByEmp(int id)
    {
        var response = await _apiClient.Api.GetStringAsync("api/Shifts");
        var allData = JsonSerializer.Deserialize<List<ShiftDTO>>(response);
        var data = allData?.Where(x => x.EmployeeId == id).ToList();
        return data;
    }
}