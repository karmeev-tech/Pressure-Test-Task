using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressure.Commands.Graphic;
using Pressure.Commands.Settings;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Pressure.DataLibrary.Model
{
    internal class SettingsLabelsCollection
    {
        public ObservableCollection<Label> CollectionLs { get => GetCollectionLs(); }

        private ObservableCollection<Label> GetCollectionLs()
        {
            return new ObservableCollection<Label>
            {
                new Label(){Content = "Давление"},
                new Label(){Content = "Верхнее огр. номинала"}
            };
        }
    }
}
