using DataLibrary;
using DataLibrary.Model;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Pressure.VM
{
    public class SettingsViewModel
    {
        public SettingsViewModel()
        {
            DataAccess da = new DataAccess();
            _rbs = da.GetSettingsRBs();
            _tbs = da.GetSettingsTBs();
        }

        private ObservableCollection<RadioButton> _rbs;

        public ObservableCollection<RadioButton> RBs
        {
            get { return _rbs; }
            set { _rbs = value; }
        }

        private ObservableCollection<TextBox> _tbs;

        public ObservableCollection<TextBox> TBs
        {
            get { return _tbs; }
            set { _tbs = value; }
        }
    }
}
