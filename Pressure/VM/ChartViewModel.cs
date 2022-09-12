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

namespace Pressure.VM
{
    public class ChartViewModel : INotifyPropertyChanged
    {
        public ChartViewModel()
        {
            DataAccess da = new DataAccess();
            SeriesCollection = da.GetFirstSeriesCollection();
            Buttons = da.GetGraphicBs();
            Values = new ChartValues<ObservablePoint>
            {
               new ObservablePoint(0,0)
            };
            SetTimer();
            _timerAndSafeValues.Add(_timer);
            _timerAndValue.Add(_timer);
            _timerAndValue.Add(_dependentValue);
            CreateFileWatcher(@"..\..\JSON\");
            Buttons[0].CommandParameter = _timerAndValue;
            Buttons[1].CommandParameter = _timerAndSafeValues;
        }

        #region Fields
        private ChartValues<ObservablePoint> _values;
        private static int _dependentValue = 0; //обслуживается ивентом
        private readonly List<object> _timerAndValue = new List<object>();
        private ObservableCollection<Button> _buttons;
        readonly JSONReader _jsonFile = new JSONReader();
        private int _counter = 0; //only for x steps
        readonly private ObservableCollection<object> _timerAndSafeValues = new ObservableCollection<object>();
        readonly private List<string> _safeValues = new List<string>();
        private static System.Timers.Timer _timer;
        readonly Experiment _experiment = new Experiment();

        private int _x = 0; //после замены ивента убрать
        #endregion

        #region Properties
        public int DependentValue { get { return _dependentValue; } set { _dependentValue = value; } }
        public ChartValues<ObservablePoint> Values 
        { 
            get { return _values; }
            set { 
                _values = value; 
                if(_timerAndSafeValues.Count == 2)
                {
                    _timerAndSafeValues[1] = _safeValues;
                }
                else
                {
                    _timerAndSafeValues.Add(_safeValues);
                }
            } 
        }
        public SeriesCollection SeriesCollection { get; set; }
        public ObservableCollection<Button> Buttons 
        {
            get { return _buttons; }
            set { _buttons = value; }
        }
        public string[] BarLabels { get; set; }

        public Func<double, string> Formatter { get; set; }
        #endregion

        public void SetTimer()
        {
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += TimerElapsed;
            _timer.AutoReset = true;
            _timer.Enabled = false;
        }

        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DependentValue = _experiment.StartExperiment(_dependentValue,_jsonFile.GetTypeOfPressure(),_jsonFile.GetLimitation());
            DependentValue = _dependentValue;
            OnPropertyChanged("DependentValue");
            Values.Add(new ObservablePoint(_counter, DependentValue));
            _safeValues.Add(Convert.ToString(Convert.ToString(_dependentValue)));
            _counter++;
            if (_timerAndSafeValues.Count != 3)
            {
                _timerAndSafeValues.Add(_jsonFile.GetTypeOfPressure());
            }
            OnPropertyChanged("Values");
        }

        #region File Watcher Event 
        public void CreateFileWatcher(string path)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = path;
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "*.json";
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            if(_x == 0)
            {
                _dependentValue = _jsonFile.GetPressure()[1];
                _x++;
            }
            _timerAndValue[1] = _dependentValue;
        }
        #endregion  //вместо него сделать такой ивент чтоб он один раз прочитал и всё, когда кнопка старт например нажата

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        
    }
}
