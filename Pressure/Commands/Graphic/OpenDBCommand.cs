using Pressure.View;

namespace Pressure.Commands.Graphic
{
    public class OpenDBCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            DBWindow dbWindow = new DBWindow();
            dbWindow.Show();
        }
    }
}
