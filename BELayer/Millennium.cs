using System;
using System.Collections.Generic;
using System.Text;

namespace BELayer
{
    class Millennium
    {
        public int millenniumNumber { get; set; }
        public List<Century> centuries { get; set; }

        public Millennium()
        {
            millenniumNumber = 0;
            centuries = new List<Century>();
        }

        public Millennium Clone()
        {
            return new Millennium
            {
                millenniumNumber = this.millenniumNumber,
                centuries = this.centuries
            };
        }

        public Millennium(Calendar calendar, int currentMillennium)
        {
            millenniumNumber = currentMillennium;
            for (int centuryNum = 0; centuryNum < 10; centuryNum++)
            {
                Century century = new Century(calendar, millenniumNumber, centuryNum);
                centuries.Add(century);
            }

        }
    }
}
