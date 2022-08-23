using DataLibrary.Model;
using LiveCharts;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace DataLibrary
{
    public class DataAccess
    {
        readonly FirstSeriesCollection _startCollection = new FirstSeriesCollection();

        public SeriesCollection GetFirstSeriesCollection()
        {
            return _startCollection.Collection;
        }

        readonly SettingsRBCollection _settingsRBCollection = new SettingsRBCollection();

        public ObservableCollection<RadioButton> GetSettingsRBs() 
        {
            return _settingsRBCollection.CollectionRBs;
        }

        readonly SettingsTBCollection _settingsTBCollection = new SettingsTBCollection();

        public ObservableCollection<TextBox> GetSettingsTBs()
        {
            return _settingsTBCollection.CollectionTBs;
        }
    }
}
