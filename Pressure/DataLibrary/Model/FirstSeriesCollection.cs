using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Pressure.JSON;
using System;
using System.Collections.Generic;

namespace Pressure.DataLibrary.Model
{
    internal class FirstSeriesCollection
    {
        public SeriesCollection Collection { get => GetFirstSeriesCollection(); }
        private SeriesCollection GetFirstSeriesCollection()
        {
            return new SeriesCollection {
                new LineSeries
                {
                    Title = "Давление"
                }
            };
        }
    }
}
