using System.Text.RegularExpressions;

namespace ShiftLoggerApp.Services;

public class ValidatorServiceHelper
{
    public Regex _DobRegex { get; private set; } 
    public Regex _NameRegex { get; private set; }


    public ValidatorServiceHelper()
    {
        _DobRegex = new Regex(@"^(0[1-9]|1[012])[-/.](0[1-9]|[12][0-9]|3[01])[-/.](19|20)\\d\\d$");
        _NameRegex = new Regex(@"^[A-Za-z\s]{1,}[\.]{0,1}[A-Za-z\s]{0,}$");
    }
}