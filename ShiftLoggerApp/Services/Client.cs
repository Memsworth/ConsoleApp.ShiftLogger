namespace ShiftLoggerApp.Services;

public class Client
{
    public HttpClient ApiClient { get; }

    public Client(string url)
    {
        ApiClient = new HttpClient
        {
            BaseAddress = new Uri(url)
        };
        ApiClient.DefaultRequestHeaders.Clear();
    }
}