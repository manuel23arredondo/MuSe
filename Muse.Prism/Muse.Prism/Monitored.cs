﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Muse.Prism
{
    public class Monitored
    {
        public string Name { get; set; }

        public string FathersName { get; set; }

        public override string ToString()
        {
            return (Name + ' ' + FathersName);
        }
    }
}
