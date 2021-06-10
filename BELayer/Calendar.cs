using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BELayer
{
    public class Calendar
    {
        public List<Year> years { get; set; }

        public Calendar() { years = new List<Year>(); }

        public Calendar(int finalYear)
        {  
            initializeFirstYear();

            for (int currentYear = Configuration.InitialYear + 1; currentYear <= finalYear; currentYear++)
            {
                addLeapDays();                
                Year year = new Year(currentYear);
                years.Add(year);
                setTime();
            }
        }

        private void initializeFirstYear()
        {
            years = new List<Year>();
            Year year = new Year(Configuration.InitialYear);
            years.Add(year);            
            setTime();           
            //assuming shortest posible year will adjust based on rules
            Configuration.daysInMonth[(int)Configuration.months.Hesvan] = Configuration.daysInShortMonth;
            Configuration.daysInMonth[(int)Configuration.months.Kislev] = Configuration.daysInShortMonth;
        }

        private void addLeapDays()
        {           
            if (Configuration.daysToPushOff.Contains(Configuration.dayOfTheWeek)) { addDayTo((int)Configuration.months.Kislev); }

            
            else if (Configuration.hour >= 18)
            {
                
                addDayTo((int)Configuration.months.Kislev);
                //Console.WriteLine("type 2");
                if (Configuration.daysToPushOff.Contains(Configuration.dayOfTheWeek)) { addDayTo((int)Configuration.months.Hesvan); }
            }

            //need to fix this           
            else if (years.Last().numOfMonths == Configuration.monthsInStandardYear && Configuration.dayOfTheWeek == (int)Configuration.dayNumbers.Tuesday
                && Configuration.hour >= 9 && Configuration.helek >= 204)
            {
                Console.WriteLine("type 3");
                Console.WriteLine(Configuration.hour + ", " + Configuration.helek);
                addDayTo((int)Configuration.months.Kislev);
                Console.WriteLine(Configuration.hour + ", " + Configuration.helek);
                addDayTo((int)Configuration.months.Hesvan);
                Console.WriteLine(Configuration.hour + ", " + Configuration.helek);
            }

            else if (years.Last().numOfMonths == Configuration.monthsInLeapYear
                && Configuration.hour >= 15 && Configuration.helek >= 589)
            {
                //Console.WriteLine("type 4");
                addDayTo((int)Configuration.months.Kislev);
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
                    addedDay.nameOfDayOfWeek = Configuration.dayNames[addedDay.dayOfWeek];
                    addedDay.numOfDay = Configuration.daysInLongMonth;
                    month.days.Add(addedDay);        
                    month.numOfDays++;
                    Configuration.incrementDayOfWeek();
                }

                years.Last().daysInYear++;

                if (month.numOfMonth > monthToAddDayTo)
                {
                    foreach (var day in month.days)
                    {
                        day.dayOfWeek = (day.dayOfWeek % Configuration.daysInWeek) + 1;
                        day.nameOfDayOfWeek = Configuration.dayNames[day.dayOfWeek];
                    }
                }
            }
        }

        void setTime()
        {
            int timeSpent = 0;
            foreach (var month in years.Last().months)
            {
                timeSpent += month.numOfDays * Configuration.standardDay;
            }
            
            int actualTime = Configuration.standardMonth * years.Last().numOfMonths;
            int timeDiffernce = actualTime - timeSpent;
            Console.WriteLine("hour" + Configuration.hour + "helek" + Configuration.helek);
            Configuration.AddTime(timeDiffernce);
            Console.WriteLine("hour" + Configuration.hour + "helek" + Configuration.helek);
            Console.WriteLine();
        }
    }
}
