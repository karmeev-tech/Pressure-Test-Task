using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Pressure.DataLibrary.Model
{
    internal class ComboBoxCollection
    {
        public ObservableCollection<string> CBCollection { get => GetComboBox(); }
        private ObservableCollection<string> GetComboBox()
        {
            return CreateComboBox();
        }
        private ObservableCollection<string> CreateComboBox()
        {
            ObservableCollection<string> comboItem = new ObservableCollection<string>()
            {
                "Эмуляция статического значения давления",
                "Эмуляция падения давления с определенным шагом",
                "Эмуляция увеличения давления с определенным шагом",
                "Эмуляция случайного давления, но с верхним ограничением номинала",
            };
            return comboItem;
        }
    }
}
