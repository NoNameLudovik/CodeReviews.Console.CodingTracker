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

    internal static int GetId()
    {
        while (true)
        {
            var sessionId = AnsiConsole.Ask<int>("Type in [green]ID[/] of session you want to edit?");
            if (!Helper.CheckIdExist(sessionId))
            {
                AnsiConsole.MarkupLine($"[red]{sessionId}[/] doesn't exist! Try again!");
                continue;
            }
            
            return sessionId;
        }
    }

    internal static bool TimeValidation(DateTime newTime, int sessionId, EditOptions option)
    {
        var session = DataBaseController.SelectFromTable(sessionId);
        
        switch (option)
        {
            case EditOptions.EditStartTime:
                if (newTime < DateTime.ParseExact(session.EndTime, "dd-MM-yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None))
                {
                    return true;
                }
                break;
            case EditOptions.EditEndTime:
                if (newTime > DateTime.ParseExact(session.StartTime,"dd-MM-yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None))
                {
                    return true;
                }
                break;
        }
        
        return false;
    }

    internal static bool CompareDates(DateTime startTime, DateTime endTime)
    {
        if (startTime > endTime)
            return false;
        
        return true;
    }

    private static bool CheckIdExist(int sessionId)
    {
        var codingSessions = DataBaseController.SelectFromTable();
        var ids = new List<int>();

        foreach (var session in codingSessions)
        {
            ids.Add(session.Id);
        }
        
        return ids.Contains(sessionId);
    }
}