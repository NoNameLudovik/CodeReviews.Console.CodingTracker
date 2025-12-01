using Spectre.Console;

namespace NoNameLudovik.CodingTracker;

internal static class Helper
{
    internal static DateTime GetDateTime()
    {
        return AnsiConsole.Ask("Please, type in date like shown in [green]brackets[/] or leave it blank to type in [green]current time[/]", DateTime.Now);
    }
}