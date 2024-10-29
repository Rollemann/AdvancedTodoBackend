using System.Configuration;

namespace TodoList.Application.Validators;

internal class ColorValidator
{
    private const string _colorRegex = @"^#[0-9a-fA-F]{6}$";

    public static bool IsColorString(string color)
    {
        var colorValidator = new RegexStringValidator(_colorRegex);

        try
        {
            colorValidator.Validate(color);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
