using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Pressure.DataLibrary;
using LiveCharts;
using LiveCharts.Defaults;
using System.Collections.Generic;
using Pressure.JSON;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO;
using Pressure.Model;
using System.Windows;

namespace Pressure.VM
{
    public class ChartViewModel : INotifyPropertyChanged
    {
        public ChartViewModel()
        {
            DataAccess da = new DataAccess();
            Buttons = da.GetGraphicBs();
            Values = new ChartValues<ObservablePoint>
            {
               new ObservablePoint(0,0)
            };
            SetTimer();

            //set state
            _watcher.Path = @"..\..\JSON\";
            _watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            _watcher.Filter = "*.json";
            _watcher.Changed += new FileSystemEventHandler(OnChanged);
            _watcher.EnableRaisingEvents = true;
            _safeValues.Add(".");

            _endState.Add(_timer);//0
            _endState.Add(_safeValues);//1
            _endState.Add(0);//2
            //

            Buttons[0].CommandParameter = _timer;
            Buttons[1].CommandParameter = _endState;
            Buttons[0].Click += StartButton_Click;
            Buttons[1].Click += StopButton_Click;
            Buttons[2].Click += SettingsButton_Click;
        }

        #region Fields
        readonly FileSystemWatcher _watcher = new FileSystemWatcher();

        private ChartValues<ObservablePoint> _values;
        private static int _dependentValue;
        private ObservableCollection<Button> _buttons;
        readonly JSONReader _jsonFile = new JSONReader();
        private List<string> _safeValues = new List<string>();
        private static System.Timers.Timer _timer;
        readonly Experiment _experiment = new Experiment();

        readonly private List<object> _endState = new List<object>(2);
        #endregion

        #region Properties
        public int DependentValue { get { return _dependentValue; } set { _dependentValue = value;} }
        public ChartValues<ObservablePoint> Values 
        { 
            get { return _values; }
            set { 
                _values = value; 
            } 
        }

        public ObservableCollection<Button> Buttons 
        {
            get { return _buttons; }
            set { _buttons = value; }
        }
        public string[] BarLabels { get; set; }

        public Func<double, string> Formatter { get; set; }
        #endregion

        #region Timer and TimerEvent

        private int _counter = 0;
        public void SetTimer()
        {
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += TimerElapsed;
            _timer.AutoReset = true;
            _timer.Enabled = false;
        }
        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var type = _jsonFile.GetTypeOfPressure();
            var limitation = _jsonFile.GetLimitation();

            Console.WriteLine(DependentValue);
            DependentValue = _experiment.StartExperiment(DependentValue, type, limitation);
            OnPropertyChanged("DependentValue");

            Values.Add(new ObservablePoint(_counter, DependentValue));
            OnPropertyChanged("Values");

            _safeValues.Add(Convert.ToString(DependentValue));

            Console.WriteLine(_counter);
            _counter++;
            Console.WriteLine(_counter);

            _endState[2] = type;
            
        }
        #endregion

        #region File Watcher Event 
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            DependentValue = _jsonFile.GetPressure()[1];
            _watcher.EnableRaisingEvents = false;
        }
        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Button Events
        void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Buttons[0].IsEnabled = false;
            Buttons[1].IsEnabled = true;
        }

        void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            _safeValues = (List<string>)_endState[1];
            _watcher.EnableRaisingEvents = true;
            Buttons[0].IsEnabled = true;
        }

        void StopButton_Click(object sender, RoutedEventArgs e)
        {
            var value = new ChartValues<ObservablePoint> { new ObservablePoint(0, 0) };
            Values = value;
            OnPropertyChanged("Values");
            Buttons[1].IsEnabled = false;
            _counter = 0;
        }
        #endregion
    }
}
