namespace ShiftLoggerApp.Validation;

public class UserInputValidator
{
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
        ValidationHelper.ValidateInput(input, ValidationHelper.NameRegex);

    public bool GetValidDob(string input) => ValidationHelper.ValidateInput(input, ValidationHelper.DobRegex);

    public bool GetValidEmail(string input) => ValidationHelper.ValidEmail(input);
}