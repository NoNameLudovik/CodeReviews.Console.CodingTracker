namespace NoNameLudovik.CodingTracker;

public class CodingSession
{
    internal int Id{get;set;}
    internal DateTime StartTime{get;set;}
    internal DateTime EndTime{get;set;}
    internal TimeSpan Duration{get;set;}

    internal CodingSession(int id, DateTime startTime, DateTime endTime)
    {
        Id = id;
        StartTime = startTime;
        EndTime = endTime;
        Duration = CalculateDuration();
    }

    internal CodingSession(DateTime startTime, DateTime endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
        Duration = CalculateDuration();
    }

    private TimeSpan CalculateDuration()
    {
        return EndTime - StartTime;
    }
    
    
}