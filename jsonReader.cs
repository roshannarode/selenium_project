using Selenium_project.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Selenium_project
{
    public class jsonReader
    {
        public static JsonNode  userData_Json(String filename)
        {
            string jsonfilepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
            string jsonString = File.ReadAllText(jsonfilepath);

            var jsonData = JsonSerializer.Deserialize<JsonNode>(jsonString);

            return jsonData;

           
        }

        
        
    }
}
