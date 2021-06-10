using System;
using System.Collections.Generic;
using System.Text;

namespace BELayer
{
    public class Year
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

        public Year Clone()
        {
            return new Year
            {
                yearNum = this.yearNum,
                yearCycleNum = this.yearCycleNum,
                numOfMonths = this.numOfMonths,
                daysInYear = this.daysInYear,
                months = this.months
            };
        }

        public Year(int currentYear)
        {
            yearNum = currentYear;
            int cycleNumber = (currentYear % Configuration.leapYearCycle);
            if (cycleNumber == 0) { cycleNumber = Configuration.leapYearCycle; }
            yearCycleNum = cycleNumber;

            numOfMonths = Configuration.monthsInStandardYear;
            if (Configuration.leapyears.Contains(cycleNumber)) { numOfMonths++; }
            setMonths(numOfMonths);
        }

        public void setMonths(int numOfMonths)
        {
            months = new List<Month>();
            Month month = new Month();

            //even for non leap years it is simpler to skip adar 1 then to add it
            for (int currentMonth = 1; currentMonth <= Configuration.monthsInLeapYear; currentMonth++)
            {
                if (currentMonth == (int)Configuration.months.Adar && numOfMonths == Configuration.monthsInStandardYear)
                {
                    currentMonth++;
                    month = new Month(currentMonth);
                    month.nameOfMonth = Configuration.monthNames[(int)Configuration.months.Adar];
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
            str += "Year" + yearNum + "\n";
            str += "Months: " + numOfMonths + "\n";
            return str;
        }
    }
}
