using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace DataLibrary.Model
{
    internal class GraphicButtonsCollection
    {
        public ObservableCollection<Button> CollectionBs { get => GetCollectionBs(); }

        private ObservableCollection<Button> GetCollectionBs()
        {
            return new ObservableCollection<Button>
            {
                new Button(){Content = "Старт"},
                new Button(){Content = "Стоп"},
                new Button(){Content = "Настройки"}
            };
        }
    }
}
