using System.Net.Mail;
using System.Text.RegularExpressions;

namespace ShiftLoggerApp.Validation;

public static class ValidationHelper
{
    public static Regex DobRegex { get; } = new(@"^(0[1-9]|1[012])[-/.](0[1-9]|[12][0-9]|3[01])[-/.](19|20)\\d\\d$", RegexOptions.Compiled);
    public static Regex NameRegex { get; } = new(@"^[A-Za-z\s]{1,}[\.]{0,1}[A-Za-z\s]{0,}$", RegexOptions.Compiled);

    public static bool ValidEmail(string input)
    {
        var valid = MailAddress.TryCreate(input, out MailAddress? mailAddress);
        return valid;
    }

    public static bool ValidateInput(string input, Regex regex)
    {
        var match = regex.Match(input);
        return match.Success;
    }

    public static bool ValidShift(string input) => DateTime.TryParse(input, out DateTime result);
}