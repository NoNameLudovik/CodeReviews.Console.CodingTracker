using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Configuration.Json;
using Dapper;
using Microsoft.Data.Sqlite;

namespace NoNameLudovik.CodingTracker;

internal class DataBaseController
{
    static IConfigurationRoot _config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional:false, reloadOnChange:true).Build();
    private SqliteConnection _connection = new SqliteConnection(_config["connectionString"]);

    internal DataBaseController()
    {
        //CreatTable();
    }

    internal void CreatTable()
    {
        string createTableSql =
            @"CREATE TABLE codingSessions (
            Id INTEGER PRIMARY KEY AUTOINCREMENT, 
            StartTime TEXT, 
            EndTime TEXT, 
            Duration TEXT);";
        _connection.Execute(createTableSql);
    }
    
    /*internal void Insert(string startTime, string endTime) 
    {
        string insertSql = @"INSERT INTO codingSessions (StartTime, EndTime, Duration) VALUES (@startTime, @EndTime, @Duration)";
        
        _connection.Execute(insertSql, startTime, endTime,);
    }*/
}