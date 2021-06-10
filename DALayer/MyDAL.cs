using System;
using System.Collections.Generic;
using System.Text;
using BELayer;

namespace DALayer
{
    internal class MyDAL : IDAL
    {
        bool IDAL.createCalendar(int lastYear)
        {
            DataSource.Calendar = new Calendar(lastYear);
            return true;
        }

        Calendar IDAL.GetCalendar()
        {
            return DataSource.Calendar;
        }
    }
}
