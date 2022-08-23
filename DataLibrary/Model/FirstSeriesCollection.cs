using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace DataLibrary.Model
{
    internal class FirstSeriesCollection
    {
        public SeriesCollection Collection { get => GetFirstSeriesCollection(); }
        private SeriesCollection GetFirstSeriesCollection()
        {
            return new SeriesCollection {
                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0,0),
                        new ObservablePoint(1,0),
                        new ObservablePoint(2,0),
                        new ObservablePoint(3,0)
                    },
                    Title = "Давление"
                }
            };
        }
    }
}
