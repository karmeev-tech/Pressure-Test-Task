using Pressure.JSON;
using System;
using System.Collections.ObjectModel;

namespace Pressure.Commands.Settings
{
    public class SetValueCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            ObservableCollection<string> values = (ObservableCollection<string>)parameter;
            SetTypeOfExperiment(values);
        }

        private void SetTypeOfExperiment(ObservableCollection<string> values)
        {
            JSONWriter writer = new JSONWriter();
            writer.WriteParamsToJSON(Convert.ToInt32(values[1]), Convert.ToInt32(values[0]), values[2]);
        }
    }
}
