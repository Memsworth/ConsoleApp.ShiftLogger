namespace ShiftLogging.Services;

public class ApiClient
{
    public HttpClient Api { get; }
    
    public ApiClient(string url)
    {
        Api = new HttpClient
        {
            BaseAddress = new Uri(url)
        };
        Api.DefaultRequestHeaders.Clear();
    }
}