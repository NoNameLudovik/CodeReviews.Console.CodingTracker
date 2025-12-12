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
                    EditSession();
                    Console.ReadKey();
                    break;
                case MenuOptions.DeleteSession:
                    DeleteSession();
                    Console.ReadKey();
                    break;
                case MenuOptions.ShowSessions:
                    ShowSessions();
                    Console.ReadKey();
                    break;
                case MenuOptions.Exit:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    private static void AddSession()
    {
        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[bold yellow]Add Session[/]\n");
        
        AnsiConsole.MarkupLine("[blue]Start Time[/]");
        var startTime = Helper.GetDateTime();
        
        AnsiConsole.MarkupLine("[blue]End Time[/]");
        var endTime = Helper.GetDateTime();
        
        /*var session = new CodingSession(startTime, endTime);*/
        DataBaseController.Insert(startTime, endTime);
        /*AnsiConsole.MarkupLine(string.Format("{0}:{1:mm}:{1:ss}", (int)session.Duration.TotalHours, session.Duration));
        AnsiConsole.Ask<string>("");*/
    }

    private static void EditSession()
    {
        ShowSessions();
        
        var sessionId = AnsiConsole.Ask<int>("Type in [green]ID[/] of session you want to edit?");
        var editOption = AnsiConsole.Prompt(new SelectionPrompt<EditOptions>().
            Title("Choose what you want to edit:").
            AddChoices(Enum.GetValues<EditOptions>()));
        
        AnsiConsole.Clear();
        var newTime = Helper.GetDateTime();

        DataBaseController.UpdateRowInTable(sessionId, newTime.ToString("dd-MM-yyyy HH:mm"),  editOption);
        
        AnsiConsole.MarkupLine("[green]Success[/]");
    }

    private static void DeleteSession()
    {
        ShowSessions();
        var sessionId = AnsiConsole.Ask<int>("Type in [green]ID[/] of session you want to delete?");
        DataBaseController.DeleteFromTable(sessionId);
    }

    private static void ShowSessions()
    {
        var codingSessions = DataBaseController.SelectFromTable();
        var table = new Table();
        table.AddColumn(new TableColumn("[green]ID[/]").Centered());
        table.AddColumn(new TableColumn("[blue]StartTime[/]").Centered());
        table.AddColumn(new TableColumn("[blue]EndTime[/]").Centered());
        table.AddColumn(new TableColumn("[yellow]Duration[/]").Centered());
        table.ShowRowSeparators();
        table.Border(TableBorder.Rounded);

        foreach (var codingSession in codingSessions)
        {
            codingSession.CalculateDuration();
            table.AddRow(codingSession.Id.ToString(), 
                codingSession.StartTime, 
                codingSession.EndTime, 
                string.Format("{0}:{1:mm}:{1:ss}", (int)codingSession.Duration.TotalHours, codingSession.Duration));
        }

        AnsiConsole.Write(table);
    }
    
}