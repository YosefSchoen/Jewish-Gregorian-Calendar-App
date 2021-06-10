using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarFactory
{
    class Month
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

        public Month(int currentMonth)
        {
            numOfMonth = currentMonth;
            nameOfMonth = Data.monthNames[numOfMonth];
            numOfDays = Data.daysInMonth[currentMonth];
            days = new List<Day>();

            for (int i = 1; i <= numOfDays; i++)
            {
                Day day = new Day(i);
                days.Add(day);
                Data.incrementDayOfWeek();
            }
        }

        public override string ToString()
        {
            string str = "\t";
            str += nameOfMonth + " ";
            str += numOfDays + "\n";
            foreach (var day in days) { str += day.ToString(); }
            str += "\n";
            return str;
        }

    }
}
