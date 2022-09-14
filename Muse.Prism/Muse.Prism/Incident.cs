using System;
using System.Collections.Generic;
using System.Text;

namespace Muse.Prism
{
    public class Incident
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
