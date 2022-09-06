using Pressure.JSON;
using Pressure.Model;

namespace Pressure.Commands.Graphic
{
    public class StartCommand : BaseCommands
    {

        public override void Execute(object parameter)
        {
            var param = (System.Timers.Timer) parameter;
            JSONReader jSONReader = new JSONReader();
            switch (jSONReader.GetType())
            {
                case 0:
                    StaticPressure staticPressure = new StaticPressure();
                    staticPressure.StaticExperiment(ref param);
                    break;
                case 1:
                    FallPressure fallPressure = new FallPressure();
                    break;
                case 2:
                    MagnificationPressure magnificationPressure = new MagnificationPressure();
                    break;
                case 3:
                    RandomPressure randomPressure = new RandomPressure();
                    break;
            }
        }
    }
}
