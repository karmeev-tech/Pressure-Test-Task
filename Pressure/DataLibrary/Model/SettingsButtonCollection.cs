using Pressure.Commands.Graphic;
using Pressure.Commands.Settings;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Pressure.DataLibrary.Model
{
    internal class SettingsButtonCollection
    {
        public ObservableCollection<Button> CollectionBs { get => GetCollectionBs(); }

        private ObservableCollection<Button> GetCollectionBs()
        {
            return new ObservableCollection<Button>
            {
                new Button(){Content = "Установить"}
            };
        }
    }
}
