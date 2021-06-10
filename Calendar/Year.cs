using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarFactory
{
    class Year
    {
        public int yearNum { get; set; }
        public int yearCycleNum { get; set; }
        public int numOfMonths { get; set; }
        public int daysInYear { get; set; }
        public List<Month> months { get; set; }
        

        public Year()
        {
            yearNum = 0;
            yearCycleNum = 0;
            numOfMonths = 0;
            daysInYear = 0;
            months = new List<Month>();
        }

        public Year(int currentYear)
        {
            yearNum = currentYear;
            int cycleNumber = (currentYear % Data.leapYearCycle);
            if(cycleNumber == 0) { cycleNumber = Data.leapYearCycle; }
            yearCycleNum = cycleNumber;

            numOfMonths = Data.monthsInStandardYear;
            if (Data.leapyears.Contains(cycleNumber)) { numOfMonths++; }
            setMonths(numOfMonths);
        }


        public void setMonths(int numOfMonths)
        {
            months = new List<Month>();
            Month month = new Month();

            //even for non leap years it is simpler to skip adar 1 then to add it
            for (int currentMonth = 1; currentMonth <= Data.monthsInLeapYear; currentMonth++) 
            {
                if (currentMonth == (int)Data.months.Adar && numOfMonths == Data.monthsInStandardYear)
                {
                    currentMonth++;
                    month = new Month(currentMonth);
                    month.nameOfMonth = Data.monthNames[(int)Data.months.Adar];
                }

                else { month = new Month(currentMonth); }

                months.Add(month);
            }
        }

        public void setDaysInYear()
        {
            daysInYear = 0;
            foreach (var month in months)
            {
                daysInYear += month.numOfDays;
            }
        }


        public override string ToString()
        {
            string str = "";
            str += yearNum + " ";
            str += numOfMonths + "\n";
            foreach (var month in months) { str += month.ToString(); }
            str += "\n";
            return str;
        }
    }
}
