using Spectre.Console;

namespace NoNameLudovik.CodingTracker;

internal class MenuController
{
    internal static void MainMenu()
    {
        while (true)
        {
            Console.Clear();

            var optionChoice = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOptions>()
                .Title("Choose an option:")
                .AddChoices(Enum.GetValues<MenuOptions>()));

            switch (optionChoice)
            {
                case MenuOptions.AddSession:
                    AddSession();
                    break;
                case MenuOptions.EditSession:
                    AnsiConsole.Markup("Edit session");
                    break;
                case MenuOptions.DeleteSession:
                    AnsiConsole.Markup("Delete session");
                    break;
                case MenuOptions.ViewSessions:
                    AnsiConsole.Markup("View sessions");
                    break;
                case MenuOptions.Exit:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    internal static void AddSession()
    {
        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[bold yellow]Add Session[/]\n");
        
        AnsiConsole.MarkupLine("[blue]Start Time[/]");
        var startTime = Helper.GetDateTime();
        
        AnsiConsole.MarkupLine("[blue]End Time[/]");
        var endTime = Helper.GetDateTime();
        
        var session = new CodingSession(startTime, endTime);
        
        AnsiConsole.MarkupLine(string.Format("{0}:{1:mm}:{1:ss}", (int)session.Duration.TotalHours, session.Duration));
        AnsiConsole.Ask<string>("");
    }
}