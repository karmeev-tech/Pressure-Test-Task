using LiveCharts;
using LiveCharts.Defaults;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressure.JSON
{
    public class JSONWriter
    {
        public dynamic WriteToJSON()
        {
            string json = File.ReadAllText(@"..\..\JSON\values.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<JSONValue>(json);
            return jsonObj;
        }

        public void WriteTypeToJSON(int pressureValue)
        {
            dynamic jsonObj = WriteToJSON();
            jsonObj.Type = pressureValue;
            Output(jsonObj);
        }

        public void WriteValueToJSON(List<string> values)
        {
            dynamic jsonObj = WriteToJSON();
            string outputValues = "";

            for(int i = 0; i < values.Count; i++)
            {
                outputValues += values[i] + ", ";
            }
            jsonObj.Safe = outputValues;
            Output(jsonObj);
        }

        public void WritePressureValueToJSON(int value)
        {
            dynamic jsonObj = WriteToJSON();
            jsonObj.Pressure[1] = value;
            Output(jsonObj);
        }

        private void Output(dynamic jsonObj)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.None);
            File.WriteAllText(@"..\..\JSON\values.json", output);
        }
    }
}
