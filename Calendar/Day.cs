using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarFactory
{
    
    public class Day
    {
        public int numOfDay { get; set; }
        public int dayOfWeek { get; set; }
        public string nameOfDayOfWeek { get; set; }

        public Day()
        {
            numOfDay = 0;
            dayOfWeek = 0;
            nameOfDayOfWeek = "";
        }

        public Day(int currentDay)
        {
            numOfDay = currentDay;
            dayOfWeek = Data.dayOfTheWeek;
            nameOfDayOfWeek = Data.dayNames[dayOfWeek];
        }

        public override string ToString()
        {
            string str = "\t\t";
            str += nameOfDayOfWeek;
            str += " " + numOfDay + "\n";

            return str;
        }
    }
}
