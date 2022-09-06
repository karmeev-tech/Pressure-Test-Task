using Pressure.Commands.Settings;
using Pressure.DataLibrary;
using Pressure.DataLibrary.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pressure.VM
{
    public class SettingsViewModel
    {
        public SettingsViewModel()
        {
            DataAccess da = new DataAccess();
            _saveParams = da.GetParamsButton();
            _saveParams[0].Command = SettingsCommands.GetSendValueCommand();
            _typeOfExperiment = da.GetComboBoxCollection();
            PressureType = 0;
        }

        private string _pressureValue = "";
        public string PressureValue
        {
            get { return _pressureValue; }
            set 
            { 
                _pressureValue = value;
                _experimentValues[0] = _pressureValue;
                _saveParams[0].CommandParameter = _experimentValues;
                Console.WriteLine("Pressure:" + _pressureValue); 
            }
        }
        private int _pressureType;
        public int PressureType
        {
            get { return _pressureType; }
            set
            {
                _pressureType = value;
                _experimentValues[1] = Convert.ToString(_pressureType);
                Console.WriteLine("Type:" + PressureType);
            }
        }
        private ObservableCollection<string> _experimentValues = new ObservableCollection<string>{"",""};
        public ObservableCollection<string> ExperimentValues
        {
            get { return _experimentValues; }
            set { _experimentValues = value; }
        }

        private ObservableCollection<Button> _saveParams;
        public ObservableCollection<Button> SaveParams 
        { 
            get { return _saveParams; } 
            set { _saveParams = value; }
        }

        private ObservableCollection<string> _typeOfExperiment;
        public ObservableCollection<string> TypeOfExperiment
        {
            get { return _typeOfExperiment; }
            set { _typeOfExperiment = value; }
        }

        readonly SettingsCommandsCollection SettingsCommands = new SettingsCommandsCollection();
    }
}
