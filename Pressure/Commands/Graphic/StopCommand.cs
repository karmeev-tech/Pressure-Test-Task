using Pressure.JSON;
using Pressure.Model.Database;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pressure.Commands.Graphic
{
    public class StopCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            var param = (ObservableCollection<object>)parameter;
            var timer = (System.Timers.Timer)param[1];
            timer.Enabled = false;
            var values = (List<string>)param[0];
            var type = (int)param[2];
            JSONWriter writer = new JSONWriter();
            writer.WriteSafeToJSON(values);
            SendToDB(writer.Safe, type);
        }

        private void SendToDB(string safe, int type)
        {
            safe = safe.Remove(0,1);
            safe = safe.Remove(safe.Length-3,3);
            DBSender sender = new DBSender();
            switch (type)
            {
                case 0:
                    sender.Type = "Эмуляция статического значения давления";
                    sender.Type = "Статика";
                    break;
                case 1:
                    sender.Type = "Эмуляция падения давления с определенным шагом";
                    sender.Type = "Падение";
                    break;
                case 2:
                    sender.Type = "Эмуляция увеличения давления с определенным шагом";
                    sender.Type = "Увеличение";
                    break;
                case 3:
                    sender.Type = "Эмуляция случайного давления, но с верхним ограничением номинала";
                    sender.Type = "Случайный";
                    break;
            }
            sender.Safe = safe;
            sender.SendToDB();
        }
    }
}
