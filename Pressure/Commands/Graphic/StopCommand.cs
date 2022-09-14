using Pressure.JSON;
using Pressure.Model.Database;
using System;
using System.Collections.Generic;

namespace Pressure.Commands.Graphic
{
    public class StopCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            var param = (List<object>)parameter;

            var timer = (System.Timers.Timer)param[0];
            var values = (List<string>)param[1];
            var type = (int)param[2];

            timer.Enabled = false;
            JSONWriter writer = new JSONWriter();
            writer.WriteSafeToJSON(values);
            Send(writer.Safe, type);

            List<string> emptyList = new List<string>();
            writer.WriteSafeToJSON(emptyList);
            param[1] = emptyList;
        }

        private void Send(string safe, int type)
        {
            safe = safe.Remove(0,1);
            if (safe[0] == '.')
            {
                safe = safe.Remove(0, 2);
            }
            safe = safe.Remove(safe.Length-3,3);
            DBSender sender = new DBSender();
            switch (type)
            {
                case 0:
                    sender.Type = "Эмуляция статического значения давления";
                    break;
                case 1:
                    sender.Type = "Эмуляция падения давления с определенным шагом";
                    break;
                case 2:
                    sender.Type = "Эмуляция увеличения давления с определенным шагом";
                    break;
                case 3:
                    sender.Type = "Эмуляция случайного давления, но с верхним ограничением номинала";
                    break;
            }
            sender.Safe = safe;
            sender.SendToDB();
        }
    }
}
