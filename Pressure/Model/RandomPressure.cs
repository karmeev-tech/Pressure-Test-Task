using Pressure.JSON;
using System;

namespace Pressure.Model
{
    internal class RandomPressure : MajorExperiment
    {
        public override void StartExperiment()
        {
            JSONReader jSONReader = new JSONReader();
            var pressure = jSONReader.ReadJsonFile().Pressure;

            /// <summary>
            /// Стабильный рандом от -10 до 10
            /// </summary>
            Random rnd = new Random();
            int randomValue = rnd.Next(-11, 11);
            pressure[1] = pressure[1] + randomValue;

            JSONWriter writer = new JSONWriter();
            writer.WritePressureValueToJSON(pressure[1]);
        }
    }
}
