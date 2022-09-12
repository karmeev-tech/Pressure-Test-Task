using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Pressure.JSON
{
    public class JSONReader
    {
        //метод оболочка необходимый, чтобы привязанные к нему части кода, выполнялись независимо от изменений в этом классе
        public JSONValue ReadJsonFile()
        {
            return ProcessRead();
        }
        private JSONValue ProcessRead()
        {
            string jsonText = File.ReadAllText(@"..\..\JSON\values.json");
            var jsonFile = JsonConvert.DeserializeObject<JSONValue>(jsonText);
            return jsonFile;
        }

        #region Getters
        public List<int> GetPressure()
        {
            var values = ProcessRead().Pressure;
            return values;
        }

        public int GetTypeOfPressure()
        {
            var value = ProcessRead().Type;
            return value;
        }

        public int GetLimitation()
        {
            var value = ProcessRead().UpperLimitation;
            return Convert.ToInt32(value);
        }
        #endregion
    }
}
