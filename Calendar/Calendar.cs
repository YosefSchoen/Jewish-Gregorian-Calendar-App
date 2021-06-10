using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarFactory
{
    class Calendar
    {
        public List<Year> years { get; set; }

        public Calendar() { years = new List<Year>(); }

        public Calendar(int finalYear)
        {
            initializeFirstYear();

            for (int currentYear = Data.InitialYear+1; currentYear <= finalYear; currentYear++)
            {
                addLeapDays();
                setTime();
                Year year = new Year(currentYear);
                years.Add(year);
            }
        }

        private void initializeFirstYear()
        {
            years = new List<Year>();
            Year year = new Year(Data.InitialYear);
            years.Add(year);
            setTime();

            //assuming shortest posible year will adjust based on rules
            Data.daysInMonth[(int)Data.months.Hesvan] = Data.daysInShortMonth;
            Data.daysInMonth[(int)Data.months.Kislev] = Data.daysInShortMonth;
        }

        private void addLeapDays()
        {
            
            int firstDayOfTishri = Data.dayOfTheWeek % 7;
            if(firstDayOfTishri == 0) {
                firstDayOfTishri = 7;
            }

            if (Data.daysToPushOff.Contains(firstDayOfTishri)) { addDayTo((int)Data.months.Kislev); }


            else if (Data.hour >= 18)
            {
                addDayTo((int)Data.months.Kislev);
                //Console.WriteLine("type 2");
                if (Data.daysToPushOff.Contains(Data.dayOfTheWeek)) { addDayTo((int)Data.months.Hesvan); }
            }

            //need to fix this           
            else if (years.Last().numOfMonths == Data.monthsInStandardYear && Data.dayOfTheWeek == (int)Data.dayNumbers.Tuesday
                && Data.hour >= 9 && Data.helek >= 204)
            {
                //Console.WriteLine("type 3");
                addDayTo((int)Data.months.Kislev);
                addDayTo((int)Data.months.Hesvan);
            }

            else if(years.Last().numOfMonths == Data.monthsInLeapYear
                && Data.hour >= 15 && Data.helek >= 589)
            {
                //Console.WriteLine("type 4");
                addDayTo((int)Data.months.Kislev);
            }
        }

        private void addDayTo(int monthToAddDayTo)
        {
            foreach (var month in years.Last().months)
            {
                if (month.numOfMonth == monthToAddDayTo)
                {
                    Day addedDay = new Day();
                    addedDay.dayOfWeek = (month.days.Last().dayOfWeek % 7) + 1;
                    addedDay.nameOfDayOfWeek = Data.dayNames[addedDay.dayOfWeek];
                    addedDay.numOfDay = Data.daysInLongMonth;
                    month.days.Add(addedDay);
                    month.numOfDays++;
                    Data.incrementDayOfWeek();
                }
                years.Last().daysInYear++;

                if (month.numOfMonth > monthToAddDayTo)
                {
                    foreach (var day in month.days)
                    {
                        day.dayOfWeek = (day.dayOfWeek % Data.daysInWeek) + 1;
                        day.nameOfDayOfWeek = Data.dayNames[day.dayOfWeek];
                    }
                }
            }
        }

        void setTime()
        {
            int timeSpent = 0;
            foreach (var month in years.Last().months)
            {
                 timeSpent += month.numOfDays * Data.standardDay;
            }
            int actualTime = Data.standardMonth * years.Last().numOfMonths;
            int timeDiffernce = timeSpent - actualTime;
            Data.AddTime(0, timeDiffernce);
        }
    }
}
