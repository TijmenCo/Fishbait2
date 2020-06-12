using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DAL
{
    public class ConnectionString
    {
        public static string GetConnection()
        {
            var myJsonString = File.ReadAllText("appsettings.json");
            var myJObject = JObject.Parse(myJsonString);
            var connectionString = myJObject.SelectToken("FishbaitDatabase");
            return connectionString.ToString();
        }
    }
}
