using BusinessLayer.DTO.Employee;
using ShiftLoggerApp.Validation;

namespace ShiftLoggerApp.Services;

public interface ICrudService<T>
{
    public Task Add(T serviceObject, Client httpClient);
    public Task Delete(int serviceObjectId, Client httpClient);
    public Task Update(int serviceObjectId, T serviceObject, Client httpClient);
    public void Get(T serviceObject, Client httpClient);
    public Task<T> CreateServiceObject(UserInputValidator userInputService);
}