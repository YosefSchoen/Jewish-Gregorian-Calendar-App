using System.Collections.Generic;

namespace CalendarFactory
{
    //Data class holds all constants and useful data used in program
    static class Data
    {
        public const int standardHelek = 1; //a helek is 1/ 1080 of an hour here it is our base unit of mesurment
        public const int standardHour = 1080 * standardHelek; //we are defining hour as a multiple of helek
        public const int standardDay = 24 * standardHour; //same as before but for day

        //1 lunar month = 29 days + 12 hours + 793 helekim
        public const int standardMonth = (29 * standardDay) + (12 * standardHour) + (793 * standardHelek);
        public const int monthsInStandardYear = 12;
        public const int monthsInLeapYear = monthsInStandardYear + 1;
        public const int daysInShortMonth = 29;
        public const int daysInLongMonth = daysInShortMonth + 1;
        public const int daysInWeek = 7;
        public const int leapYearCycle = 19;

        static public List<int> daysToPushOff = new List<int> { 1, 4, 6 }; //rosh hashana cannot fall on these days
        static public List<int> leapyears = new List<int> { 3, 6, 8, 11, 14, 17, 19 }; //these are the leap years

        public enum months
        {
            Tishri = 1,
            Hesvan,
            Kislev,
            Tevet,
            Shevat,
            Adar, //only added during leap year
            VeAdar, //VeAdar renamed to Adar during non leap year
            Nisan,
            Iyar,
            Sivan,
            Tamuz,
            Av,
            Elul
        }

        //mapping month numbers to names
        public static Dictionary<int, string> monthNames = new Dictionary<int, string>
        {
            {1, "Tishri" },
            {2, "Hesvan" },
            {3, "Kislev" },
            {4, "Tevet" },
            {5, "Shevat" },
            {6, "Adar" }, //only added during leap year
            {7, "VeAdar" }, //VeAdar renamed to Adar during non leap year
            {8, "Nisan" },
            {9, "Iyar" },
            {10, "Sivan" },
            {11, "Tamuz" },
            {12, "Av" },
            {13, "Elul" },
            
        };

        //mapping month numbers to days in the months
        public static Dictionary<int, int> daysInMonth = new Dictionary<int, int>
        {
            {1, 30 }, //Tishri
            {2, 29 }, //Hesvan
            {3, 30 }, //Kislev
            {4, 29 }, //Tevet
            {5, 30 }, //Shevat
            {6, 30 }, //Adar only added during leap year
            {7, 29 }, //VeAdar renamed to Adar during non leap year
            {8, 30 }, //Nisan
            {9, 29 }, //Iyar
            {10, 30 }, //Sivan
            {11, 29 }, //Tamuz
            {12, 30 }, //Av
            {13, 29 }, //Elul
        };

        public enum dayNumbers
        {
            Sunday = 1,
            Monday,
            Tuesday,
            Wednasday,
            ThursDay,
            Friday,
            Shabbat,
        }

        //mapping days in week numbers to names
        public static Dictionary<int, string> dayNames = new Dictionary<int, string>
        {
            {1, "Sunday" },
            {2, "Monday" },
            {3, "Tuesday" },
            {4, "Wednesday" },
            {5, "Thursday" },
            {6, "Friday" },
            {7, "Shabbat" },
        };


        public static int InitialYear = 1; //initial year is 1 not 0
        public static int dayOfTheWeek = 2; //initial day is a monday
        public static int hour = 5; // initial hour
        public static int helek = 204; //initial helekim

        //day of the week cycles back to 1 after 7
        public static void incrementDayOfWeek() { dayOfTheWeek = (dayOfTheWeek % 7) + 1; }
      
        //need to define AddTime to a time in base 1080 and 24
        public static void AddTime(int hr, int he)
        {
            int helekRemainder = (helek + he) % 1080;
            int helekCarryOver = (helek + he) / 1080;

            int hourRemainder = (hour + helekCarryOver) % 24;
            int hourCarryOver = (hour + helekCarryOver) / 24;

            helek = helekRemainder;
            hour = hourRemainder;
        }
    }
}