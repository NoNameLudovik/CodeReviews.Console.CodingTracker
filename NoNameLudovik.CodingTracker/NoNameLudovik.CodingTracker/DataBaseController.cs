using System.Configuration;
using System.Collections.Specialized;
using System.Data.Common;
using Dapper;
using Microsoft.Data.Sqlite;

namespace NoNameLudovik.CodingTracker;

internal class DataBaseController
{
    
    private SqliteConnection connection = new SqliteConnection(ConfigurationManager.AppSettings["connectionString"]);
}