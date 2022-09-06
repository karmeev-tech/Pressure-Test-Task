using Pressure.View;

namespace Pressure.Commands.Graphic
{
    public class OpenSettingsCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Show();
        }
    }
}
