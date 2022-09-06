using System.Windows.Input;

namespace Pressure.Commands.Settings
{
    internal class SettingsCommandsCollection
    {
        private ICommand SendValues => new SetValueCommand();
        public ICommand GetSendValueCommand()
        {
            return SendValues;
        }

    }
}
