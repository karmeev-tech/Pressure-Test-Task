using Pressure.Commands.Graphic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pressure.DataLibrary.Model
{
    internal class GraphicButtonsCollection
    {
        public ObservableCollection<Button> CollectionBs { get => GetCollectionBs(); }

        private ObservableCollection<Button> GetCollectionBs()
        {
            return new ObservableCollection<Button>
            {
                new Button(){Content = "Старт",Command = _commands.GetStart()},
                new Button(){Content = "Стоп",Command = _commands.GetStop()},
                new Button(){Content = "Настройки",Command = _commands.GetOpenSettingsCommand()}
            };
        }

        readonly private GraphicCommandsCollection _commands = new GraphicCommandsCollection();
    }
}
