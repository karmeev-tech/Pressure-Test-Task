using Pressure.JSON;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pressure.Commands.Graphic
{
    public class StopCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            var param = (ObservableCollection<object>)parameter;
            var timer = (System.Timers.Timer)param[1];
            timer.Enabled = false;
            var values = (List<string>)param[0];
            JSONWriter writer = new JSONWriter();
            writer.WriteValueToJSON(values);
        }
    }
}
