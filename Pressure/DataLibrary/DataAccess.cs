using Pressure.DataLibrary.Model;
using LiveCharts;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Pressure.DataLibrary
{
    public class DataAccess
    {
        readonly FirstSeriesCollection _startCollection = new FirstSeriesCollection();

        public SeriesCollection GetFirstSeriesCollection()
        {
            return _startCollection.Collection;
        }

        readonly SettingsTBCollection _settingsTBCollection = new SettingsTBCollection();

        public ObservableCollection<TextBox> GetSettingsTBs()
        {
            return _settingsTBCollection.CollectionTBs;
        }

        readonly GraphicButtonsCollection _graphicBCollection = new GraphicButtonsCollection();

        public ObservableCollection<Button> GetGraphicBs()
        {
            return _graphicBCollection.CollectionBs;
        }

        readonly SettingsButtonCollection _settingsButtonCollection = new SettingsButtonCollection();
        public ObservableCollection<Button> GetParamsButton()
        {
            return _settingsButtonCollection.CollectionBs;
        }

        readonly ComboBoxCollection _comboBoxCollection = new ComboBoxCollection();
        public ObservableCollection<string> GetComboBoxCollection()
        {
            return _comboBoxCollection.CBCollection;
        }
    }
}
