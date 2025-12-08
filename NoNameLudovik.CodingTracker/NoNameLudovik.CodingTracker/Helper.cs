using System.Globalization;
using Spectre.Console;

namespace NoNameLudovik.CodingTracker;

internal static class Helper
{
    internal static DateTime GetDateTime()
    {
        while (true)
        {
            var input = AnsiConsole.Ask(
                "Please, type in date at format \"dd-MM-yyyy HH:mm\" or leave it blank to type in [green]current time[/]",
                DateTime.Now.ToString("dd-MM-yyyy HH:mm"));

            if (DateTime.TryParseExact(input, "dd-MM-yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None, out var date))
                return date;
            
            AnsiConsole.MarkupLine($"Wrong format [red]{input}[/]! Try again!");
        }
    }
}