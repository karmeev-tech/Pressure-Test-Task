using System.Collections.Generic;

namespace Pressure.JSON
{
    public class JSONValue
    {
        public int Type { get; set; }
        public List<int> Pressure { get; set; }
        public string Safe { get; set; }

    }
}
