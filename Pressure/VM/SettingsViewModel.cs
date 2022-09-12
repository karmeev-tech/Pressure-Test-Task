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
            _labels = da.GetLabelsCollection();
            PressureType = 0;
        }

        #region Fields
        private string _pressureValue = "";
        private string _pressureUpperLimitation = "";
        private int _pressureType;
        private ObservableCollection<string> _experimentValues = new ObservableCollection<string> { "", "" };
        private ObservableCollection<Button> _saveParams;
        private ObservableCollection<Label> _labels;
        private ObservableCollection<string> _typeOfExperiment;
        #endregion

        #region Properties

        public string PressureUpperLimitation
        {
            get { return _pressureUpperLimitation; }
            set
            {
                _pressureUpperLimitation = value;
                _experimentValues.Add(_pressureUpperLimitation);
            }
        }

        public string PressureValue
        {
            get { return _pressureValue; }
            set
            {
                _pressureValue = value;
                _experimentValues[0] = _pressureValue;
                _saveParams[0].CommandParameter = _experimentValues;
            }
        }
        public int PressureType
        {
            get { return _pressureType; }
            set
            {
                _pressureType = value;
                _experimentValues[1] = Convert.ToString(_pressureType);
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
        public ObservableCollection<Label> Labels
        {
            get { return _labels; }
            set { _labels = value; }
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
