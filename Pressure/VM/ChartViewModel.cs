using System;
using System.Collections.ObjectModel;
using DataLibrary;
using DataLibrary.Model;
using LiveCharts;

namespace Pressure.VM
{
    public class ChartViewModel
    {
        public ChartViewModel()
        {
            DataAccess da = new DataAccess();
            SeriesCollection = da.GetFirstSeriesCollection();          
        }

        public SeriesCollection SeriesCollection { get; set; }

        public string[] BarLabels { get; set; }

        public Func<double, string> Formatter { get; set; }
    }
}
