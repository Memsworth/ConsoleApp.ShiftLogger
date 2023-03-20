namespace ShiftLoggerApp.Services;

public class UserInputService
{
    private ValidatorService _validatorService { get; }
    private ValidatorServiceHelper _validatorServiceHelper { get; }
    
    public UserInputService()
    {
        _validatorService = new ValidatorService();
        _validatorServiceHelper = new ValidatorServiceHelper();
    }
    
    public string GetInput(string message, Func<string, bool> validatorFunc)
    {
        Console.Write(message);
        string input;
        do
        {
            input = Console.ReadLine()!;
        } while (!validatorFunc(input));
        return input;
    }


    public bool GetValidName(string input) =>
        _validatorService.ValidateInput(input, _validatorServiceHelper._NameRegex);

    public bool GetValidDob(string input) => _validatorService.ValidateInput(input, _validatorServiceHelper._DobRegex);

    public bool GetValidEmail(string input) => _validatorService.ValidEmail(input);
}