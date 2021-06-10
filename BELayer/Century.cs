using System;
using System.Collections.Generic;
using System.Text;

namespace BELayer
{
    class Century
    {
        public int milleniumNum { get; set; }
        public int centuryNum { get; set; }
        public List<Decade> decades;

        public Century()
        {
            centuryNum = 0;
            decades = new List<Decade>();
        }

        public Century Clone()
        {
            return new Century
            {
                centuryNum = this.centuryNum,
                decades = this.decades
            };
        }

        public Century(Calendar calendar, int currentMillenium, int currentCentury)
        {
            milleniumNum = currentMillenium;
            centuryNum = currentCentury;

            for (int decadeNum = 0; decadeNum < 10; decadeNum++)
            {
                Decade decade = new Decade(calendar, milleniumNum, centuryNum, decadeNum);
                decades.Add(decade);
            }
        }
    }
}
