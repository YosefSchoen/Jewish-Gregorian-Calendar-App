using System;
using System.Collections.Generic;
using System.Text;

namespace BELayer
{
    class Decade
    {
        public int milleniumNum { get; set; }
        public int centuryNum { get; set; }
        public int decadeNum { get; set; }
        public List<Year> years { get; set; }

        public Decade()
        {

            decadeNum = 0;
            years = new List<Year>();
        }

        public Decade Clone()
        {
            return new Decade
            {
                decadeNum = this.decadeNum,
                years = this.years
            };
        }

        public Decade(Calendar calendar, int currentMillenium, int currentCentury,int currentDecade)
        {
            milleniumNum = currentMillenium;
            centuryNum = currentCentury;
            decadeNum = currentDecade;

            for (int yearNum = 0; yearNum < 10; yearNum++)
            {
                int fullYearNum = (1000 * milleniumNum) + (100 * centuryNum) + 10*decadeNum + yearNum;
                if (fullYearNum < calendar.years.Count)
                {
                    Year year = calendar.years[fullYearNum];
                    years.Add(year);
                }
               
            }
        }
    }
}
