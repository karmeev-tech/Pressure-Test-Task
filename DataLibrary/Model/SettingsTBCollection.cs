using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DataLibrary.Model
{
    internal class SettingsTBCollection
    {
        public ObservableCollection<TextBox> CollectionTBs { get => GetCollectionTBs(); }

        private ObservableCollection<TextBox> GetCollectionTBs()
        {
            return new ObservableCollection<TextBox>
            {
                new TextBox(){Text = "Давление"},
                new TextBox(){Text = "Время"}
            };
        }
    }
}
