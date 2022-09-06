using Pressure.JSON;

namespace Pressure.Model
{
    internal class FallPressure
    {

        public void FallExperiment(ref System.Timers.Timer timer)
        {
            timer.Enabled = true;
        }

        private void StartExperiment()
        {
            JSONReader jSONReader = new JSONReader();
            var pressure = jSONReader.ReadJsonFile().Pressure;

            JSONWriter writer = new JSONWriter();
            writer.WritePressureValueToJSON(pressure[1]);
        }
    }
}
