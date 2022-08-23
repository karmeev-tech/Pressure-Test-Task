using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace DataLibrary.Model
{
    internal class SettingsRBCollection
    {
        public ObservableCollection<RadioButton> CollectionRBs { get => GetCollectionRBs();}

        private ObservableCollection<RadioButton> GetCollectionRBs()
        {
            return new ObservableCollection<RadioButton>
            {
                new RadioButton(){Content = "Эмуляция статического значения давления"},
                new RadioButton(){Content = "Эмуляция падения либо увеличения давления с определенным шагом"},
                new RadioButton(){Content = "Эмуляция случайного давления, но с верхним ограничением номинала"}
            };
        }
    }
}
