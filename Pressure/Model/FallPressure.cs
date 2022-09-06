using Pressure.JSON;

namespace Pressure.Model
{
    internal class FallPressure : MajorExperiment
    {

        //public void FallExperiment(ref System.Timers.Timer timer)
        //{
        //    timer.Enabled = true;
        //    while (!timer.Enabled == false)
        //    {
        //        StartExperiment();
        //    }
        //}

        async public override void StartExperiment()
        {
            JSONReader jSONReader = new JSONReader();
            var pressure = jSONReader.ReadJsonFile().Pressure;

            /// <summary>
            /// Стабильное падение на 10
            /// </summary>
            pressure[1] = pressure[1] - 10;

            JSONWriter writer = new JSONWriter();
            writer.WritePressureValueToJSON(pressure[1]);
        }
    }
}
