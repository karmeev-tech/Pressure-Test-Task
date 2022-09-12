using Pressure.DataLibrary.Model;
using LiveCharts;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Pressure.DataLibrary
{
    public class DataAccess
    {

        #region Settings

        readonly ComboBoxCollection _comboBoxCollection = new ComboBoxCollection();
        public ObservableCollection<string> GetComboBoxCollection()
        {
            return _comboBoxCollection.CBCollection;
        }

        readonly SettingsButtonCollection _settingsButtonCollection = new SettingsButtonCollection();
        public ObservableCollection<Button> GetParamsButton()
        {
            return _settingsButtonCollection.CollectionBs;
        }

        readonly SettingsLabelsCollection _settingsLabelsCollection = new SettingsLabelsCollection();

        public ObservableCollection<Label> GetLabelsCollection()
        {
            return _settingsLabelsCollection.CollectionLs;
        }

        #endregion

        #region Graphic

        readonly FirstSeriesCollection _startCollection = new FirstSeriesCollection();

        public SeriesCollection GetFirstSeriesCollection()
        {
            return _startCollection.Collection;
        }

        readonly GraphicButtonsCollection _graphicBCollection = new GraphicButtonsCollection();

        public ObservableCollection<Button> GetGraphicBs()
        {
            return _graphicBCollection.CollectionBs;
        }

        #endregion
    }
}
