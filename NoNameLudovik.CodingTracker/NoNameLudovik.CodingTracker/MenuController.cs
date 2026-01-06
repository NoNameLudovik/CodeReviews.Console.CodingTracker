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
        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold yellow]Add Session[/]\n");

            AnsiConsole.MarkupLine("[blue]Start Time[/]");
            var startTime = Helper.GetDateTime();

            AnsiConsole.MarkupLine("[blue]End Time[/]");
            var endTime = Helper.GetDateTime();

            if (startTime > endTime)
            {
                AnsiConsole.MarkupLine("[red]StartTime[/] can't be later then [red]EndTime[/]!");
                Console.ReadKey();
                continue;
            }

            try
            {
                DataBaseController.Insert(startTime, endTime);
                AnsiConsole.MarkupLine("[green]Success![/]Session added!");
            }
            catch (Exception error)
            {
                AnsiConsole.MarkupLine($"[red]{error.Message}[/]");
            }

            break;
        }
    }

    private static void EditSession()
    {
        ShowSessions();
        
        DateTime newTime;
        var sessionId = Helper.GetId();
        var editOption = AnsiConsole.Prompt(new SelectionPrompt<EditOptions>().
            Title("Choose what you want to edit:").
            AddChoices(Enum.GetValues<EditOptions>()));

        while (true)
        {
            AnsiConsole.Clear();
            newTime = Helper.GetDateTime();
            if (!Helper.TimeValidation(newTime, sessionId, editOption))
            {
                AnsiConsole.MarkupLine("[red]StartTime[/] can't be later then [red]EndTime[/]!");
                Console.ReadKey();
                continue;
            }

            break;
        }

        try
        {
            DataBaseController.UpdateRowInTable(sessionId, newTime.ToString("dd-MM-yyyy HH:mm"), editOption);
            
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[green]Success![/]Date was changed!");
        }
        catch (Exception error)
        {
            AnsiConsole.MarkupLine($"[red]{error.Message}[/]");
        }
    }

    private static void DeleteSession()
    {
        ShowSessions();
        
        var sessionId = Helper.GetId();
        try
        {
            DataBaseController.DeleteFromTable(sessionId);
            AnsiConsole.MarkupLine("[green]Success![/]Session deleted!");
        }
        catch(Exception error)
        {
            AnsiConsole.MarkupLine($"[red]{error.Message}[/]");
        }
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