using LiveCharts;
using LiveCharts.Defaults;
using Pressure.JSON;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Pressure.Model
{
    internal class StaticPressure
    {
        public void StaticExperiment(ref System.Timers.Timer timer)
        {
            timer.Enabled = true ;
        }

    }
}
