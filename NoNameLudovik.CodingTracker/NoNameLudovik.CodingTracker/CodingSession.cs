namespace NoNameLudovik.CodingTracker;

public class CodingSession
{
    private int Id{get;set;}
    private DateTime StartTime{get;set;}
    private DateTime EndTime{get;set;}
    public TimeSpan Duration{get;set;}

    internal CodingSession(int id, DateTime startTime, DateTime endTime)
    {
        Id = id;
        StartTime = startTime;
        EndTime = endTime;
        Duration = CalculateDuration();
    }

    private TimeSpan CalculateDuration()
    {
        return EndTime - StartTime;
    }
    
    
}