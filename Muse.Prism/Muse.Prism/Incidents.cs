using System;
using System.Collections.Generic;
using System.Text;

namespace Muse.Prism
{
    public class Incidents
    {
        public string Action { get; set; }
        public string Ubication { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return Action;
        }
    }
}
