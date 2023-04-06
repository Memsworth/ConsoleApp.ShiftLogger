using ShiftLoggerApp.Validation;

namespace ShiftLoggerApp.Services;

public interface ICrudService<T>
{
    public Task Add(T serviceObject);
    public Task Delete(int serviceObjectId);
    public Task Update(int serviceObjectId, T serviceObject);
    public Task<T> Get<T>(string requestUri);
    public Task<T> CreateServiceObject(UserInputValidator userInputService);
}