using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Configuration.Json;
using Dapper;
using Microsoft.Data.Sqlite;

namespace NoNameLudovik.CodingTracker;

internal class DataBaseController
{
    static IConfigurationRoot _config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional:false, reloadOnChange:true).Build();
    static SqliteConnection _connection = new SqliteConnection(_config["connectionString"]);

    // internal DataBaseController()
    // {
    //     CreatTable();
    // }

    internal static void CreatTable()
    {
            string createTableSqlQuery =
                @"CREATE TABLE IF NOT EXISTS codingSessions (
            Id INTEGER PRIMARY KEY AUTOINCREMENT, 
            StartTime TEXT, 
            EndTime TEXT);";
            _connection.Execute(createTableSqlQuery);
    }
    
    internal static void Insert(DateTime startTime, DateTime endTime) 
    {
            string insertSqlQuery =
                @"INSERT INTO codingSessions (StartTime, EndTime) VALUES (@StartTime, @EndTime)";

            var newSession = new {StartTime = startTime.ToString("dd-MM-yyyy HH:mm"), EndTime = endTime.ToString("dd-MM-yyyy HH:mm")};
            _connection.Execute(insertSqlQuery, newSession);
    }

    internal static List<CodingSession> SelectFromTable()
    {
        string selectSqlQuery = @"SELECT * FROM codingSessions";
        
        var codingSessions = _connection.Query<CodingSession>(selectSqlQuery).ToList();
        return codingSessions;
    }

    internal static void DeleteFromTable(int sessionId)
    {
        string deleteSqlQuery = @"DELETE FROM codingSessions WHERE Id = @sessionId";
        _connection.Execute(deleteSqlQuery, new { sessionId });
    }
}