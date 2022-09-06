using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Pressure.JSON
{
    public class JSONReader
    {
        public JSONValue ReadJsonFile()
        {
            string jsonText = File.ReadAllText(@"..\..\JSON\values.json");
            var jsonFile = JsonConvert.DeserializeObject<JSONValue>(jsonText);
            return jsonFile;
        }

        public List<int> GetPressure()
        {
            var values = ReadJsonFile().Pressure;
            return values;
        }

        public int GetType()
        {
            var value = ReadJsonFile().Type;
            return value;
        }
    }
}
