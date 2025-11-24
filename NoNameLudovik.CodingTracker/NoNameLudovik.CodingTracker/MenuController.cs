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
                    AnsiConsole.Ask("Add session", DateTime.Now);
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
}