using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Pressure.DataLibrary.Model
{
    internal class SettingsTBCollection
    {
        public ObservableCollection<TextBox> CollectionTBs { get => GetCollectionTBs(); }

        private ObservableCollection<TextBox> GetCollectionTBs()
        {
            return new ObservableCollection<TextBox>
            {
                new TextBox()
            };
        }
    }
}
