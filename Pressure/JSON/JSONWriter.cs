using System.Collections.Generic;
using System.IO;

namespace Pressure.JSON
{
    public class JSONWriter
    {
        #region Read and Write to JSON
        public dynamic GetJSON()
        {
            JSONReader reader = new JSONReader();
            return reader.ReadJsonFile();
        }

        private void Output(dynamic jsonObj)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.None);
            Safe = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj.Safe, Newtonsoft.Json.Formatting.None);
            File.WriteAllText(@"..\..\JSON\values.json", output);
        }
        #endregion

        #region Pressure,Type,Safe

        public string Safe { get; set; }
        public void WriteSafeToJSON(List<string> values)
        {
            dynamic jsonObj = GetJSON();
            string outputValues = "";

            for(int i = 0; i < values.Count; i++)
            {
                outputValues += values[i] + "| ";
            }
            jsonObj.Safe = outputValues;
            Output(jsonObj);
        }
        public void WriteParamsToJSON(int type,int pressure,string limitation)
        {
            dynamic jsonObj = GetJSON();
            jsonObj.Type = type;
            jsonObj.Pressure[1] = pressure;
            jsonObj.UpperLimitation = limitation;
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.None);
            File.WriteAllText(@"..\..\JSON\values.json", output);
        }
        #endregion
    }
}
