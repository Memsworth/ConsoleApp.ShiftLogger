using System.Net.Mail;
using System.Text.RegularExpressions;

namespace ShiftLoggerApp.Services;

public class ValidatorService
{
    
    public bool ValidEmail(string input)
    {
        var valid = MailAddress.TryCreate(input, out MailAddress? mailAddress);
        return valid;
    }

    public bool ValidateInput(string input, Regex regex)
    {
        var match = regex.Match(input);
        return match.Success;
    }
}