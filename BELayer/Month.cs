using System;
using System.Collections.Generic;
using System.Text;

namespace BELayer
{
    public class Month
    {
        public int numOfMonth { get; set; }
        public string nameOfMonth { get; set; }
        public int numOfDays { get; set; }
        public List<Day> days;

        public Month()
        {
            numOfMonth = 0;
            nameOfMonth = "";
            numOfDays = 0;
            days = new List<Day>();
        }

        public Month Clone()
        {
            return new Month
            {
                numOfMonth = this.numOfMonth,
                nameOfMonth = this.nameOfMonth,
                numOfDays = this.numOfDays,
                days = this.days
            };
        }

        public Month(int currentMonth)
        {
            numOfMonth = currentMonth;
            nameOfMonth = Configuration.monthNames[numOfMonth];
            numOfDays = Configuration.daysInMonth[currentMonth];
            days = new List<Day>();

            for (int i = 1; i <= numOfDays; i++)
            {
                Day day = new Day(i);
                days.Add(day);
                Configuration.incrementDayOfWeek();
            }
        }

        public override string ToString()
        {
            string str = "";
            str += nameOfMonth + "\n";
            str += "Days: " + numOfDays + "\n";
            return str;
        }
    }
}
