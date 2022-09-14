namespace Pressure.Commands.Graphic
{
    public class StartCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            var timer = (System.Timers.Timer)parameter;
            timer.Start();
        }
    }
}
