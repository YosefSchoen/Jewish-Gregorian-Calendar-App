using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Calendar calendar = new Calendar(5778);
            foreach (var month in calendar.years.Last().months)
            {
                Console.Write(month.nameOfMonth + ": ");
                foreach (var day in month.days)
                {Conne
                    
                    if(day.numOfDay == 1)
                    {
                        Console.WriteLine(day.nameOfDayOfWeek);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
