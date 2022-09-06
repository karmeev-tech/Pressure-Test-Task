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
            _timerAndValues.Add(_timer);
        }

        #region Fields
        private ChartValues<ObservablePoint> _values;
        private ObservableCollection<Button> _buttons;
        readonly JSONReader _jsonFile = new JSONReader();
        private int _counter = 0; //only for x steps
        readonly private ObservableCollection<object> _timerAndValues = new ObservableCollection<object>();
        readonly private List<string> _stringValues = new List<string>();
        private static System.Timers.Timer _timer;
        #endregion

        #region Properties
        public ChartValues<ObservablePoint> Values 
        { 
            get { return _values; }
            set { 
                _values = value; 
                if(_timerAndValues.Count == 2)
                {
                    _timerAndValues[1] = _stringValues;
                }
                else
                {
                    _timerAndValues.Add(_stringValues);
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
            Buttons[0].CommandParameter = _timer;
            Buttons[1].CommandParameter = _timerAndValues;
        }

        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Values.Add(new ObservablePoint(_counter, _jsonFile.GetPressure()[1]));
            _stringValues.Add(Convert.ToString(_counter) + ", " + Convert.ToString(_jsonFile.GetPressure()[1]));
            _counter++;
            OnPropertyChanged("Values");
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
