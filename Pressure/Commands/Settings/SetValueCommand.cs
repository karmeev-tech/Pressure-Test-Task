using Pressure.JSON;
using Pressure.Model;
using System;
using System.Collections.ObjectModel;

namespace Pressure.Commands.Settings
{
    public class SetValueCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            ObservableCollection<string> values = (ObservableCollection<string>)parameter;
            //здесь нихуя не ставим, ток тип эксперимента, он его заебенит на chartVM
            SetTypeOfExperiment(values[1]);
        }

        private void SetTypeOfExperiment(string type)
        {
            JSONWriter writer = new JSONWriter();
            writer.WriteTypeToJSON(Convert.ToInt32(type));
        }
    }
}
