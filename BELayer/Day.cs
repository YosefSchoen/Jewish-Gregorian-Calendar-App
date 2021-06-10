using System;

namespace BELayer
{
    public class Day
    {
        public int numOfDay;
        public int dayOfWeek;
        public string nameOfDayOfWeek;

        public Day()
        {
            numOfDay = 0;
            dayOfWeek = 0;
            nameOfDayOfWeek = "";
        }

        public Day Clone()
        {
            return new Day
            {
                numOfDay = this.numOfDay,
                dayOfWeek = this.dayOfWeek,
                nameOfDayOfWeek = this.nameOfDayOfWeek
            };
        }

        public Day(int currentDay)
        {
            numOfDay = currentDay;
            dayOfWeek = Configuration.dayOfTheWeek;
            nameOfDayOfWeek = Configuration.dayNames[dayOfWeek];
        }

        public override string ToString()
        {
            string str = "";
            str += nameOfDayOfWeek;
            str += " " + numOfDay + "\n";

            return str;
        }
    }
}
