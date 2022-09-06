using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressure.Model
{
    internal class Experiment
    {
        private string _pressure;
        private string _type;
        public string Pressure { set => _pressure = value; }
        public string Type { set => _type = value; }
    }
}
