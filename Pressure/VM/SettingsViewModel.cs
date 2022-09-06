using Pressure.Commands.Settings;
using Pressure.DataLibrary;
using Pressure.DataLibrary.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

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

        #region Fields
        private string _pressureValue = "";
        private int _pressureType;
        private ObservableCollection<string> _experimentValues = new ObservableCollection<string> { "", "" };
        private ObservableCollection<Button> _saveParams;
        private ObservableCollection<string> _typeOfExperiment;
        #endregion

        #region Properties
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
        public ObservableCollection<string> ExperimentValues
        {
            get { return _experimentValues; }
            set { _experimentValues = value; }
        }

        public ObservableCollection<Button> SaveParams
        {
            get { return _saveParams; }
            set { _saveParams = value; }
        }
        public ObservableCollection<string> TypeOfExperiment
        {
            get { return _typeOfExperiment; }
            set { _typeOfExperiment = value; }
        }
        #endregion

        readonly SettingsCommandsCollection SettingsCommands = new SettingsCommandsCollection();
    }
}
