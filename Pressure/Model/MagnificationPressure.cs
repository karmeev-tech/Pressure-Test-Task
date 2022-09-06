using Pressure.JSON;

namespace Pressure.Model
{
    internal class MagnificationPressure : MajorExperiment
    {
        public override void StartExperiment()
        {
            JSONReader jSONReader = new JSONReader();
            var pressure = jSONReader.ReadJsonFile().Pressure;

            /// <summary>
            /// Стабильное увелечение на 10
            /// </summary>
            pressure[1] = pressure[1] + 10;

            JSONWriter writer = new JSONWriter();
            writer.WritePressureValueToJSON(pressure[1]);
        }
    }
}
