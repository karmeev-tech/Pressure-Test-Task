using Pressure.JSON;
using Pressure.Model;
using System.Collections.Generic;

namespace Pressure.Commands.Graphic
{
    public class StartCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            var param = (List<object>)parameter;
            var timer = (System.Timers.Timer)param[0];
            timer.Start();
        }
    }
}
