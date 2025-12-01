using System.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;

namespace NoNameLudovik.CodingTracker;

class Program
{
    static void Main(string[] args)
    {
        /*DataBaseController dataBaseController = new DataBaseController();
        dataBaseController.CreatTable();*/
        // var config = new ConfigurationBuilder()
        //     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //     .Build();
        //
        // string congratulationString = config["connectionString"];
        MenuController.MainMenu();
    }
}