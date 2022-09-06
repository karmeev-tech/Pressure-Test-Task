using System.Windows.Input;

namespace Pressure.Commands.Graphic
{
    internal class GraphicCommandsCollection
    {
        private ICommand OpenSettings => new OpenSettingsCommand();
        public ICommand GetOpenSettingsCommand()
        {
            return OpenSettings;
        }

        private ICommand Start => new StartCommand();
        public ICommand GetStart()
        {
            return Start;
        }

        private ICommand Stop => new StopCommand();
        public ICommand GetStop()
        {
            return Stop;
        }
    }
}
