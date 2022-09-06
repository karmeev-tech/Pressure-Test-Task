using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressure.Model
{
    public abstract class MajorExperiment
    {
        public void Experiment(ref System.Timers.Timer timer)
        {
            timer.Enabled = true;
            while (!timer.Enabled == false)
            {
                StartExperiment();
            }
        }

        public abstract void StartExperiment();
    }
}
