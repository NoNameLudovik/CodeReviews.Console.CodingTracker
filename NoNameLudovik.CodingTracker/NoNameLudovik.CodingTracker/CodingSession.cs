using System.Globalization;

namespace NoNameLudovik.CodingTracker;

public class CodingSession
{
    internal int Id{get;set;}
    internal string StartTime{get;set;}
    internal string EndTime{get;set;}
    internal TimeSpan Duration{get; set;}

    internal void CalculateDuration()
    {
        var endTime = DateTime.ParseExact(EndTime, "dd-MM-yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None);
        var startTime = DateTime.ParseExact(StartTime, "dd-MM-yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None);

        Duration = endTime - startTime;
    }
    
    
}