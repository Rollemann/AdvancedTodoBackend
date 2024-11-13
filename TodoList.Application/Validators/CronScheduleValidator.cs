using System.Configuration;

namespace TodoList.Application.Validators;

internal class CronScheduleValidator
{
    private const string _cronRegex = @"(@(annually|yearly|monthly|weekly|daily|hourly|reboot))|(@every (\d+(ns|us|µs|ms|s|m|h))+)|((((\d+,)+\d+|(\d+(\/|-)\d+)|\d+|\*) ?){5,7})";

    public static bool IsCronString(string cron)
    {
        var cronValidator = new RegexStringValidator(_cronRegex);

        try
        {
            cronValidator.Validate(cron);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
